using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DLCompany.Factory;
using Newtonsoft.Json;

namespace WebApplicationCompany.Controllers
{
    public class CompaniesController : ApiController
    {
        CompanyController controller = new CompanyController();

        // GET api/<controller>
        [HttpGet,  ResponseType(typeof(DLCompany.Model.CompanyHeader))]
        public async Task<IHttpActionResult> Get()
        {  
            List<DLCompany.Model.CompanyHeader> dato = await Task.Run(() => controller.GetEntities().Select(c => new DLCompany.Model.CompanyHeader { Id = c.Id, Code = c.Code, Description = c.Description, EmployeeCount = c.EmployeeCount }).ToList());

            if (dato == null)
            {
                return NotFound();
            }

            return Ok(dato); 
        }

        // GET api/<controller>/5
        [HttpGet,  ResponseType(typeof(DLCompany.Model.Company))]
        public async Task<IHttpActionResult> Get(int id)
        {
            DLCompany.Model.Company dato = await Task.Run(() => controller.GetEntity(id));
            
            if (dato == null)
            {
                return NotFound();
            }

            return Ok(dato);
        }

    }
}