using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DLCompany.Model
{
    [DataContract(Name = "Company")]
    public partial class Company: CompanyHeader
    {
       [DataMember]
       public virtual ICollection<EmployeeHeader> Employees { get; set; }

    }
}
