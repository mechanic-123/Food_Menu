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
            var data = (from user in db.TmUsermasters
                        where (user.Username == uname && user.Password == password)
                        select user.Rolename);
            if (data != null)
            {
                if (Convert.ToString(data) == "RTO Officer")
                    RedirectToAction("");
                if (Convert.ToString(data) == "Traffic Police")
                    RedirectToAction("");
                if (Convert.ToString(data) == "Driver")
                    RedirectToAction("");
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
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:12850/api/");
                    var postdata = client.PostAsJsonAsync<TmUsermaster>("User/AddUser", u);
                    postdata.Wait();
                    var res = postdata.Result;
                    ModelState.AddModelError("", res.ToString());
                    if (res.IsSuccessStatusCode)

                        ModelState.AddModelError("", "New User Added");
                }
            }
            catch (AggregateException err)
            {
                foreach (var errInner in err.InnerExceptions)
                {
                    ModelState.AddModelError("", errInner.ToString()); //this will call ToString() on the inner execption and get you message, stacktrace and you could perhaps drill down further into the inner exception of it if necessary 
                }
            }
            return View();
        }
    }
}
