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
            if (role != null)
            {
                if (Convert.ToString(role) == "RTO_Officer")
                    return RedirectToAction("RTOHome", "ConsumeRTO");
                if (Convert.ToString(role) == "Traffic_Police")
                    return RedirectToAction("HomePage", "ConsumeTrafficPolice");
                if (Convert.ToString(role) == "Vehicle_Owner")
                    return RedirectToAction("PayOffence", "ConsumeTrafficPolice");
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
                    u.Username = Request.Form["username"];
                    string rname = Request.Form["rolename"];
                    if (rname != "RTO_Officer" && rname != "Traffic_Police" && rname != "Vehicle_Owner")
                        ModelState.AddModelError("", "Invalid Rolename");
                    else
                    {
                        u.Rolename = rname;
                        u.Password = Request.Form["password"];
                        client.BaseAddress = new Uri("http://localhost:12850/api/");
                        var postdata = client.PostAsJsonAsync<TmUsermaster>("User/AddUser", u);
                        postdata.Wait();
                        var res = postdata.Result;
                        if (res.IsSuccessStatusCode)
                            ModelState.AddModelError("", "New User Added");
                    }
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
