using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLCompany.Model
{
    public partial class CompanyDBContext : DbContext
    {
        public CompanyDBContext() : base("DefaultConnection")
        {
            Database.SetInitializer<CompanyDBContext>(new DropCreateDatabaseAlways<CompanyDBContext>());
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<EmployeeHeader> Employees { get; set; }
    }
}
