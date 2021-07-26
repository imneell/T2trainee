
using HrSystem.Application.Models;
using HrSystem.Database;
using HrSystem.Datbase;
using HrSystem.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class VacationManager : IVacation
    {
        public int DeleteVacation(int id)
        {
            try
            {
                using (VacationDbContext context = new VacationDbContext(new DbContextOptions<VacationDbContext>()))
                {
                    var customer = context.Vacations.Where(z => z.Id == id).FirstOrDefault();
                    context.Vacations.Remove(customer);
                    context.SaveChanges();
                }
            }catch(Exception){

            }
            return 1;
        }

        public int RequestVacation(VacationDto vacation, int id)
        {
            VacationStatus myVar = VacationStatus.InProgress;
            int check = 0;
            try {
                using (VacationDbContext context = new VacationDbContext(new DbContextOptions<VacationDbContext>()))
                {
                    if (context.Employees.Where(z => z.Id == id).Select(x => x.VacationDays).FirstOrDefault() > 0)
                    {
                        VacationDto newVacation = new VacationDto();
                        newVacation.EmployeeId = vacation.EmployeeId;
                        newVacation.Reason = "In Progress";
                        newVacation.StartDate = vacation.StartDate;
                        newVacation.EndDate = vacation.EndDate;
                        newVacation.Status = (int)myVar;
                        int requested = (int)(vacation.EndDate - vacation.StartDate).TotalDays;
                        var Employee = context.Employees.SingleOrDefault(z => z.Id == vacation.EmployeeId);
                        if (requested <= Employee.VacationDays)
                        {
                            Employee.VacationDays = Employee.VacationDays - requested;
                            context.Vacations.Add(newVacation);
                            context.SaveChanges();
                        }

                        check = 1;
                    }
                    else
                    {
                        check = 0;
                    }

                }
            }
            catch (Exception)
            {

            }

            return check;
        }
        public VacationDto ViewVacation(int id)
        {
            VacationDto vac = new VacationDto();
            try
            {
                using (VacationDbContext context = new VacationDbContext(new DbContextOptions<VacationDbContext>()))

                {
                    vac= context.Vacations.Where(x => x.Id == id).FirstOrDefault();

                }
            }
            catch (Exception)
            {

            }
            return vac;
        }

        public int UpdateVacation(VacationDto vacation)
        {
            int check = 0;
            try
            {
                using (VacationDbContext context = new VacationDbContext(new DbContextOptions<VacationDbContext>()))
                {

                    VacationDto vacationInstance = context.Vacations.Where(Vacation => Vacation.Id == vacation.Id).FirstOrDefault();
                    EmployeeDto employeeInstance = context.Employees.Where(Employee => Employee.Id == vacation.EmployeeId).FirstOrDefault();
                    int previousRequestedLeaveDays = (int)(vacationInstance.EndDate - vacationInstance.StartDate).TotalDays + 1;

                    using (context)
                    {
                        vacationInstance.Type = vacation.Type;
                        vacationInstance.StartDate = vacation.StartDate;
                        vacationInstance.EndDate = vacation.EndDate;
                        vacationInstance.Status = vacation.Status;
                        vacationInstance.Reason = "";
                        vacationInstance.EmployeeId = vacation.EmployeeId;
                        employeeInstance.VacationDays += previousRequestedLeaveDays;

                        int UpdatedrequestedLeaveDayes = (int)(vacation.EndDate - vacation.StartDate).TotalDays + 1;

                        if (UpdatedrequestedLeaveDayes <= (employeeInstance.VacationDays + previousRequestedLeaveDays))
                        {
                            employeeInstance.VacationDays = employeeInstance.VacationDays - UpdatedrequestedLeaveDayes;
                            context.SaveChanges();
                        }

                        check = 1;

                    }
                }
            }
            catch (Exception)
            {

            }
            return check;
        }

        public List<VacationDto> ViewVacations(int id)
        {
            List<VacationDto> VacationList = new List<VacationDto>();
            try {
                using (VacationDbContext context = new VacationDbContext(new DbContextOptions<VacationDbContext>()))

                {
                    VacationList = context.Vacations.Where(x => x.EmployeeId == id).ToList<VacationDto>();

                }
            }
            catch (Exception)
            {

            }
            return VacationList;
        }

        void IVacation.ViewVacation(int id)
        {
            throw new NotImplementedException();
        }
    }
}
