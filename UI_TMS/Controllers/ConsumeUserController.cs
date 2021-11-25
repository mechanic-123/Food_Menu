using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_CRS.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace UI_TMS.Controllers
{
    public class ConsumeUserController : Controller
    {
        public IActionResult UserLogin()
        {
            return View();
        }
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(TmUsermaster u)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:28655/api/");
                var postdata = client.PostAsJsonAsync<TmUsermaster>("/api/User/AddUser", u);
                postdata.Wait();
                var res = postdata.Result;
                if (res.IsSuccessStatusCode)
                    ModelState.AddModelError("", "New User Added");
                else
                    ModelState.AddModelError("",res.ToString());
            }
            return View();
        }
    }
}
