using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_CRS.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI_TMS.Controllers
{
    public class ConsumeTrafficPoliceController : Controller
    {
        TMSDBContext db = new TMSDBContext();

        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult AddOffence()
        {
            ViewData["data"] = new SelectList(db.TmOffences, "OffenceId", "OffenceType");
            return View();
        }
        [HttpPost]
        public IActionResult AddOffence(OffenceDetail od)
        {
            ViewData["data"] = new SelectList(db.TmOffences, "OffenceId", "OffenceType");
            od.Time = DateTime.Now;
            od.OffenceId = Convert.ToInt32(Request.Form["ddloid"]);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12850");
                var postdata = client.PostAsJsonAsync<OffenceDetail>("/api/TrafficPolice/Addpenalty", od);
                postdata.Wait();
                var result = postdata.Result;
                if (result.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "New offence added To The vehicle No" + od.VehNo);
                }
                else
                    ModelState.AddModelError("", result.ToString());
            }
            return View();

        }
        public IActionResult EditOffence(int ono)
        {
            OffenceDetail od = new OffenceDetail();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12850");
                var resp = client.GetAsync("/api/TrafficPolice/Getoffencebyoffno/" + ono);
                resp.Wait();
                var result = resp.Result;
                if (result.IsSuccessStatusCode)
                {
                    var op = result.Content.ReadAsAsync<OffenceDetail>();
                    op.Wait();
                    od = op.Result;
                }

            }
            return View(od);
        }
        [HttpPost]
        public IActionResult EditOffence(int ono, OffenceDetail od)
        {
            ono = od.OffenceNo;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12850");
                var res = client.PutAsJsonAsync("/api/TrafficPolice/Editpentaly/" + ono, od);
                res.Wait();
                var op = res.Result;
                if (op.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "The penalty has been cleared by the vehicle no" + od.VehNo);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Showalloffence()
        {
            List<OffenceDetail> offlist = new List<OffenceDetail>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12850");
                var responedata = client.GetAsync("/api/TrafficPolice/Showalloffence");
                responedata.Wait();
                var result = responedata.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readresult = result.Content.ReadAsAsync<List<OffenceDetail>>();
                    readresult.Wait();
                    offlist = readresult.Result;
                }
            }
            return View(offlist);
        }
        public IActionResult GenerateReport()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GenerateReport(string vno)
        {
            vno = Request.Form["vno"];
            List<OffenceDetail> offlist = new List<OffenceDetail>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12850");
                var responedata = client.GetAsync("/api/TrafficPolice/GenerateReport/" + vno);
                responedata.Wait();
                var result = responedata.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readresult = result.Content.ReadAsAsync<List<OffenceDetail>>();
                    readresult.Wait();
                    offlist = readresult.Result;
                }
            }
            return View(offlist);
        }
        public IActionResult PayOffence()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PayOffence(string vno)
        {
            vno = Request.Form["vno"];
            List<OffenceDetail> offlist = new List<OffenceDetail>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:12850");
                var responedata = client.GetAsync("/api/TrafficPolice/GenerateReport/" + vno);
                responedata.Wait();
                var result = responedata.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readresult = result.Content.ReadAsAsync<List<OffenceDetail>>();
                    readresult.Wait();
                    offlist = readresult.Result;
                }
            }
            return View(offlist);
        }
        public IActionResult PayOut(int id)
        {
            TMSDBContext db = new TMSDBContext();
            var op = (from o in db.OffenceDetails
                      where o.OffenceId == id
                      select o).SingleOrDefault();
            op.Status = "PAID";
            db.Update(op);
            db.SaveChanges();
            return RedirectToAction("PayOffence");
        }
    }


}

