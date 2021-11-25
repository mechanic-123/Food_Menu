using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TMS_CRS.Models;

namespace UI_TMS.Controllers
{
    public class ConsumeRTOController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddOwner()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOwner(TmOwnerdetail o)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12850/api/RTO");
                var postdata = client.PostAsJsonAsync<TmOwnerdetail>("AddUser", o);
                postdata.Wait();
                var result = postdata.Result;
                if (result.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "New Ower created");
                }
            }
            return View();
        }
    }
}
