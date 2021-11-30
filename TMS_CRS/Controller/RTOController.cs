using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_CRS.DAL;
using TMS_CRS.Models;

namespace TMS_CRS.Controller
{
    [Route("api/RTO")]
    [ApiController]
    public class RTOController : ControllerBase
    {
        readonly IRTO r;
        public RTOController(IRTO r)
        {
            this.r = r;
        }
        [HttpPost]
        [Route("/api/RTO/AddUser")]
        public int Post(TmOwnerdetail o)
        {
            return r.AddOwner(o);
        }
        [HttpPost]
        [Route("/api/RTO/AddVehicle")]
        public int Post(TmVehicledetail v)
        {
            return r.AddVechile(v);
        }
        [HttpPost]
        [Route("/api/RTO/Register")]
        public int Post(TmRegdetail reg)
        {
            return r.Registration(reg);
        }
        [HttpPut]
        [Route("/api/RTO/Transferdetails/{vehId}")]
        public bool Put(TmRegdetail reg, int vehId)
        {
            return r.Transferdetails(reg, vehId);
        }
        [HttpGet]
        [Route("/api/RTO/GenerateReport/{id}")]
        public List<TmRegdetail> Get(int id)
        {
            return r.GenerateReport(id);
        }
        [HttpGet]
        [Route("/api/RTO/GetAll")]
        public List<TmRegdetail> Get()
        {
            return r.GetAll();
        }
        [HttpGet]
        [Route("/api/RTO/GetById/{id}")]
        public TmRegdetail Get(long id)
        {
            return r.GetById(id);
        }
    }
}
