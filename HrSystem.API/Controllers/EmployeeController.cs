using BusinessLayer.Models;
using HrSystem.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ActionNameAttribute = System.Web.Http.ActionNameAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace HrSystem.API.Controllers
{

  
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/GetVacations")]
        public IHttpActionResult ViewInformation(int id)
        {
            EmployeeDto employee = null;
            return (IHttpActionResult)HttpContext;
        }

        //--------------------------------------------------------------------------------------------

        [HttpGet]
        [Route("[action]")]
        [ActionName("[ViewEmployees]")]
        public List<EmployeeDto> ViewEmployees()
        {
            throw new NotImplementedException();
        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------

        [HttpPost]
        [Route("[action]")]
        [ActionName("[GivePermission/{id}]")]
        public void GivePermission(int permissionId)
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------------------
        public void SaveData(EmployeeDto employee)
        {
            EmployeeManager employee1 = new EmployeeManager();
            employee1.AddEmployee(employee);
        }
    }
}

