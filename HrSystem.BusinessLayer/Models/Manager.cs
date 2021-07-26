
using HrSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class Manager : IUser
    {
        public int AddEmployee(EmployeeDto Employee)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateLogin(string email, string password)
        {
            throw new NotImplementedException();
        }

        public int DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public bool GivePermission()
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(EmployeeDto Employee)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto ViewEmployeeInformation(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeDto> ViewEmployees()
        {
            throw new NotImplementedException();
        }
    }
}