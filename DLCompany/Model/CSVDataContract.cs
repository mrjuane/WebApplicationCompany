using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DLCompany.Model
{
    [DataContract(Name ="DATA")]
   internal class CSVDataContract
    {
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public string CompanyCode { get; set; }
        [DataMember]
        public string CompanyDescription { get; set; }
        [DataMember, Key]
        public int EmployeeId  { get; set; }
        [DataMember]
        public string EmployeeFirstName { get; set; }
        [DataMember]
        public string EmployeeLastName  { get; set; }
        [DataMember]
        public string EmployeeEmail { get; set; }
        [DataMember]
        public string EmployeeDepartment  { get; set; }
        [DataMember]
        public string EmployeeHireDate { get; set; }
}
}
