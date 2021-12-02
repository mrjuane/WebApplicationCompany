using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DLCompany.Model
{
    [DataContract(Name = "EmployeeHeader",IsReference =true)]
    public partial class EmployeeHeader
    {
        [Key,DataMember]//"EmployeeId"
        public int Id { get; set; }

        //EmployeeFirstName
        public string FirstName { get; set; }

        //EmployeeLastName
        public string LastName { get; set; }
        [DataMember]
        public string FullName {
            get
            {
                return string.Concat(this.FirstName.Trim(), " ", this.LastName.Trim());
            }
        }

        public virtual Company Company { get; set; }
    }
}