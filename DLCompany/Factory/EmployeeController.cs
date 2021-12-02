using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLCompany.Model;
using System.Data.Entity;

namespace DLCompany.Factory
{
    public sealed class EmployeeController : IBaseController<Model.EmployeeHeader>
    {

        public EmployeeController()
        {

        }

        public bool Delete(EmployeeHeader entity)
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
                throw ex;
            }
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public IEnumerable<EmployeeHeader> GetEntities()
        {
            try
            {
                using (var context = new CompanyDBContext())
                {
                    var result = context.Employees.ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeHeader GetEntity(int Id)
        {
            try
            {
                using (var context = new CompanyDBContext())
                {
                    var result = context.Employees.FirstOrDefault(c => c.Id == Id);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(EmployeeHeader entity)
        {
            try
            {
                using (var context = new CompanyDBContext())
                {
                    context.Employees.Add(entity);
                    var result = context.SaveChanges();

                    return result > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(EmployeeHeader entity)
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
                throw ex;
            }
        }
    }
}
