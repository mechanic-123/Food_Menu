using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_CRS;
using TMS_CRS.DAL;
using TMS_CRS.Models;

namespace TMS_CRS.Controller
{
    [Route("api/TrafficPolice")]
    [ApiController]
    public class TrafficPoliceController : ControllerBase
    {
        readonly ITrafficPolice T;
        readonly TMSDBContext db;
        public TrafficPoliceController(ITrafficPolice T,TMSDBContext db)
        {
            this.T = T;
            this.db = db;
        }
        [HttpPost]
        [Route("/api/TrafficPolice/Addpenalty")]
        public int Post(OffenceDetail od)
        {
            return  T.Addpenalty(od);
        }
        [HttpPut]
        [Route("/api/TrafficPolice/Editpentaly/{ono}")]
        public bool Put(OffenceDetail newval,int ono)
        {
            return T.EditPenalty(newval, ono);
        }
        [HttpGet]
        [Route("/api/TrafficPolice/GenerateReport/{vno}")]
        public OffenceDetail Get(string vno)
        {
            return T.GenerateReport(vno);
        }
             
    }
}
