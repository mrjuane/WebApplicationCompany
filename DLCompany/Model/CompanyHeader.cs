using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DLCompany.Model
{
    [DataContract(Name = "CompanyHeader")]
    public partial class CompanyHeader
    {
        // CompanyId
        [Key ,DataMember]
        public int Id { get; set; }
        // CompanyCode
        [DataMember]
        public string Code { get; set; }
        // CompanyDescription
        [DataMember]
        public string Description { get; set; }
        // Number of Employees in the given company
        [DataMember]
        public int EmployeeCount { get; set; }
        
    }
}
