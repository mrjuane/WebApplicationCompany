using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DLCompany.Helpper;

namespace WebApplicationCompany.Controllers
{
    public class UploadFileController : ApiController
    {

        // POST api/<controller>
        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            try
            {
                HttpResponseMessage result = null;

                HttpFileCollection filesCollection = HttpContext.Current.Request.Files;

                if (filesCollection.Count > 0)
                {
                    var filePath = string.Empty;
                    var fileFullName = string.Empty;

                    foreach (string item in filesCollection)
                    {
                        HttpPostedFile fileToUpload = filesCollection[item];
                       
                        var mainPath = HttpContext.Current.Server.MapPath("~/Files/");

                        if (!Directory.Exists(mainPath))
                            Directory.CreateDirectory(mainPath);

                        fileFullName = Path.Combine(mainPath, fileToUpload.FileName);

                        if (File.Exists(fileFullName))
                            File.Delete(fileFullName);

                        await Task.Run(() => fileToUpload.SaveAs(fileFullName));

                        await InsertDataFromCSVToDB(fileFullName);
                    }

                    result = Request.CreateResponse(HttpStatusCode.Created, fileFullName);
                }
                else
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [NonAction]
        private async Task InsertDataFromCSVToDB(string _fileName)
        {
            using (var helpper = new DLImportCSVData())
            {
                await helpper.ConvertExcelAndInsertToDb(_fileName);
            }
        }
    }
}