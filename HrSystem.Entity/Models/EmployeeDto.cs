﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.Database
{
    public class EmployeeDto
    {
 

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public int ManagerId { get; set; }
        public int VacationDays { get; set; }
        public bool IsManager { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<PermissionDto> Permission { get; set; }
    }
}
