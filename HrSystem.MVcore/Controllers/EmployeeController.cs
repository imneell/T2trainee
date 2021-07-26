using HrSystem.Database;
using HrSystem.MVcore.Assests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HrSystem.MVcore.Controllers
{
    public class EmployeeController : System.Web.Mvc.Controller
    {
        public APIcaller api;
        public IActionResult First()
        {
            return (IActionResult)View();
        }

        public IActionResult Login()
        {
            return (IActionResult)View();
        }

        [System.Web.Mvc.HttpGet]
        public async System.Threading.Tasks.Task<System.Web.Mvc.JsonResult> LoginAuth(string email, string password)
        {
            var response = new EmployeeDto();
            string url = "https://localhost:44322/WeatherForecast/";
            // var loginResponse = await api.

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var httpResponse = await client.GetAsync("LoginAuth");
                if (httpResponse.IsSuccessStatusCode)
                {

                    response = await httpResponse.Content.ReadAsAsync<EmployeeDto>();

                }


            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }

}
