using BusinessLayer.Models;
using HrSystem.Application.Models;
using HrSystem.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        //-----------------------------------------------------------------------------
        [HttpPost]
        [Route("[action]")]
        [ActionName("SaveData")]
        public void SaveData(EmployeeDto employee)
        {
            IUser employee1 = new EmployeeManager();
            employee1.AddEmployee(employee);
        }
        //-----------------------------------------------------------------------------
        [HttpPut]
        [Route("[action]")]
        [ActionName("UpdateData")]
        public void UpdateData(EmployeeDto employee)
        {
            IUser employee1 = new EmployeeManager();
            employee1.UpdateEmployee(employee);
        }

        //-----------------------------------------------------------------------------
        [HttpDelete]
        [Route("[action]")]
        [ActionName("Delete")]
        public void DeleteData(int id)
        {
            IUser employee1 = new EmployeeManager();
            employee1.DeleteEmployee(id);
        }
        //-----------------------------------------------------------------------------
        [HttpGet]
        [Route("[action]")]
        [ActionName("GetEmployee")]
        public void GetData(int id)
        {
            IUser employee1 = new EmployeeManager();
            employee1.ViewEmployeeInformation(id);
        }
        //-----------------------------------------------------------------------------
        [HttpGet]
        [Route("[action]")]
        [ActionName("GetEmployees")]
        public void GetDatas()
        {
            IUser employee1 = new EmployeeManager();
            employee1.ViewEmployees();
        }
        //-----------------------------------------------------------------------------
        [HttpGet]
        [Route("[action]")]
        [ActionName("GetVacations")]
        public void GetVacations(int id)
        {
            IVacation Vacation = new VacationManager();
            Vacation.ViewVacations(id);
        }
        //-----------------------------------------------------------------------------

        [HttpGet]
        [Route("[action]")]
        [ActionName("GetVacation")]
        public void GetVacation(int id)
        {
            IVacation Vacation = new VacationManager();
            Vacation.ViewVacation(id);
        }
        //-----------------------------------------------------------------------------
        [HttpGet]
        [Route("[action]")]
        [ActionName("LoginAuth")]
        public void GetLoginInfo(string email, string password)
        {
           IUser Employee = new EmployeeManager();
            Employee.AuthenticateLogin(email,password);
        }
        //-----------------------------------------------------------------------------
        [HttpPost]
        [Route("[action]")]
        [ActionName("SaveVacation")]
        public void RequestVacation(VacationDto vacation, int id)
        {
            IVacation vacation1 = new VacationManager();
            vacation1.RequestVacation(vacation, id);
        }
        //-----------------------------------------------------------------------------
        [HttpPut]
        [Route("[action]")]
        [ActionName("UpdateVacation")]
        public void UpdateVacation(VacationDto vacation)
        {
            IVacation vacation1 = new VacationManager();
            vacation1.UpdateVacation(vacation);
        }
        //-----------------------------------------------------------------------------
        [HttpDelete]
        [Route("[action]")]
        [ActionName("DeleteVacation")]
        public IActionResult DeleteVacation(int id)
        {
            IVacation vacation1 = new VacationManager();
            vacation1.DeleteVacation(id);
            return Ok();
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
