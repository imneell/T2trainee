
using HrSystem.Database;
using HrSystem.Datbase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessLayer.Models
{
    public class EmployeeManager : IUser
    {
        public int AddEmployee(EmployeeDto Employee)
        {
            int check = 0;
            try
            {
                using (VacationDbContext context = new VacationDbContext(new DbContextOptions<VacationDbContext>()))
                {
                    EmployeeDto newEmployee = new EmployeeDto();

                    newEmployee.Email = Employee.Email;
                    newEmployee.JobTitle = Employee.JobTitle;
                    newEmployee.ManagerId = Employee.ManagerId;
                    newEmployee.Name = Employee.Name;
                    newEmployee.Password = Employee.Password;
                    newEmployee.Phone = Employee.Phone;
                    context.Employees.Add(newEmployee);
                    context.SaveChanges();
                    check = 1;
                }
            }
            catch (Exception)
            {

            }
            return check;

        }

        public bool AuthenticateLogin(string email, string password)
        {
            bool check = false;
            EmployeeDto NewEmployee;
            try {
       
                using (var context = new VacationDbContext())
                {
                    NewEmployee = context.Employees.FirstOrDefault(z => z.Password == (password) && (z.Email == (email)));
                }
                if (NewEmployee == null)
                {
                    check= false;
                }
                check= true;
            }
            
           catch(Exception){


            }
            return check;
}


        public int DeleteEmployee(int id)
        {
            using (VacationDbContext context = new VacationDbContext(new DbContextOptions<VacationDbContext>()))
            {
                var Employee = context.Employees.Where(z => z.Id == id).FirstOrDefault();
                context.Employees.Remove(Employee);
                context.SaveChanges();
            }
            return 1;
        }

        public bool GivePermission()
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(EmployeeDto Employee)
        {
            try
            {
                using (VacationDbContext context = new VacationDbContext(new DbContextOptions<VacationDbContext>()))
                {
                    var result = context.Employees.SingleOrDefault(b => b.Id == Employee.Id);
                    if (result != null)
                    {
                        result.Email = Employee.Email;
                        result.JobTitle = Employee.JobTitle;
                        result.ManagerId = Employee.ManagerId;
                        result.Name = Employee.Name;
                        result.Password = Employee.Password;
                        result.Phone = Employee.Phone;
                        context.SaveChanges();

                    }
                }
            }
            catch (Exception)
            {

            }
            return 1;
        }

        public EmployeeDto ViewEmployeeInformation(int id)
        {
            EmployeeDto emp = new EmployeeDto();
            try
            {
                using (VacationDbContext context = new VacationDbContext(new DbContextOptions<VacationDbContext>()))

                {
                    emp = context.Employees.Where(x => x.Id == id).FirstOrDefault();

                }
            }
            catch (Exception)
            {

            }
            return emp;
        }
        public List<EmployeeDto> ViewEmployees()
        {

            List<EmployeeDto> EmployeeList = new List<EmployeeDto>();
            try
            {
                using (VacationDbContext context = new VacationDbContext(new DbContextOptions<VacationDbContext>()))

                {
                    EmployeeList = context.Employees.ToList<EmployeeDto>();


                }
            }
            catch (Exception)
            {

            }
             return EmployeeList;
        }

    
    }
}
