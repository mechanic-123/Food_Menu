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
        [HttpPost]
        public IActionResult UserLogin(string uname, string password)
        {
            TMSDBContext db = new TMSDBContext();
            uname = Request.Form["txtuser"];
            password = Request.Form["txtpass"];
            var role = (from u in db.TmUsermasters
                       where (u.Username == uname && u.Password == password)
                       select u.Rolename).SingleOrDefault();
            ModelState.AddModelError("", role);
            if (role != null)
            {
                if (Convert.ToString(role) == "RTO_Officer")
                    return RedirectToAction("RTOHome", "ConsumeRTO");
                if (Convert.ToString(role) == "Traffic_Police")
                    return RedirectToAction("HomePage", "ConsumeTrafficPolice");
                if (Convert.ToString(role) == "Vehicle_Owner")
                    return RedirectToAction("", "");
            }
            else
                ModelState.AddModelError("", "Invalid Username or Password");
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
                client.BaseAddress = new Uri("http://localhost:12850/api/");
                var postdata = client.PostAsJsonAsync<TmUsermaster>("User/AddUser", u);
                postdata.Wait();
                var res = postdata.Result;
                if (res.IsSuccessStatusCode)
                    ModelState.AddModelError("", "New User Added");
                else
                    ModelState.AddModelError("", res.ToString());
            }
            return View();
        }
    }
}
