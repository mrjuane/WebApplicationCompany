using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using DLCompany.Model;

namespace DLCompany.Helpper
{
    public class DLImportCSVData : IDisposable
    {
        //Read CSV file from the path
        public async Task ConvertExcelAndInsertToDb(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);

                    var listFromcvs = await Task.Run(() => csvReader.GetRecords<CSVDataContract>().ToList());

                    var result = await InsertDataToDB(listFromcvs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //take the list of the CSV object and format the data to insert into the database
        private async Task<bool> InsertDataToDB(List<CSVDataContract> listFromcvs)
        {
            try
            {
                using (CompanyDBContext context = new CompanyDBContext())
                {
                    List<Company> companies = listFromcvs.GroupBy(c => new { c.CompanyId, c.CompanyCode, c.CompanyDescription }).Select(c => new Company { Id = c.FirstOrDefault().CompanyId, Code = c.FirstOrDefault().CompanyCode, Description = c.FirstOrDefault().CompanyDescription }).ToList();

                    foreach (var item in companies)
                    {
                        item.Employees = listFromcvs.Where(c => c.CompanyId == item.Id).Select(c => new EmployeeHeader
                        {
                            Id = c.EmployeeId,
                            FirstName = c.EmployeeFirstName,
                            LastName = c.EmployeeLastName
                        }).ToList();

                        item.EmployeeCount = item.Employees.Count;

                        context.Companies.Add(item);
                    }

                    var result = await context.SaveChangesAsync();

                    return result > 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {            
           GC.SuppressFinalize(this);
        }
    }
}
