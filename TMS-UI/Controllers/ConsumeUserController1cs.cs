using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS_UI.Controllers
{
    public class ConsumeUserController1cs : Controller
    {
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser()
        {
            return View();
        }
    }
}
