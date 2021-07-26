using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.Database
{
    public class PermissionDto
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public bool Flag { get; set; }
        //many to many 
        public virtual ICollection<EmployeeDto> Employee { get; set; }
    }
}
