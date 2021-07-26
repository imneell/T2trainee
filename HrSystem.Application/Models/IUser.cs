
using HrSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Models
 
{
   public  interface IUser
    {
        public int DeleteEmployee(int id);
        public int UpdateEmployee(EmployeeDto Employee);
        public bool AuthenticateLogin(string email, string password);
        public int AddEmployee(EmployeeDto Employee);
        public EmployeeDto ViewEmployeeInformation(int id);
        public List<EmployeeDto> ViewEmployees();
        public bool GivePermission();

    }
}
