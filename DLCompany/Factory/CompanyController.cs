using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLCompany.Model;
using System.Data.Entity;

namespace DLCompany.Factory
{
    public sealed class CompanyController : IBaseController<Model.Company>
    {
        public bool Delete(Company entity)
        {
            try
            {
                using (var context = new CompanyDBContext())
                {
                    context.Entry(entity).State = EntityState.Deleted;
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public IEnumerable<Company> GetEntities()
        {
            try
            {
                using (var context = new CompanyDBContext())
                {
                    var result = context.Companies.ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Company GetEntity(int Id)
        {
            try
            {
                using (var context = new CompanyDBContext())
                {
                    var result = context.Companies.Include(c => c.Employees).FirstOrDefault(c => c.Id == Id);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(Company entity)
        {
            try
            {
                using (var context = new CompanyDBContext())
                {
                    context.Companies.Add(entity);
                   var result = context.SaveChanges();

                    return result > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Company entity)
        {
            try
            {
                using (var context = new CompanyDBContext())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    var result = context.SaveChanges();

                    return result > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
