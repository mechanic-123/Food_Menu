using System;
using TMS_CRS.DAL;
using TMS_CRS.Models;

namespace TestTMS
{
    class Program
    {
        static void Main(string[] args)
        {
            ITrafficPolice police = new TrafficPoliceImpl();

            OffenceDetail off = new OffenceDetail
            {
                VehNo = "SHP002",
                Time = DateTime.Now,
                Place = "Pari Chowk",
                OffenceId = 110,
                ReportedBy = "James",
                Status = "PAID"
            };
            //var res = police.Addpenalty(off);
            //if(res>0)
            //    Console.WriteLine("Offence Added.");
            //var res = police.EditPenalty(off, 1);
            //if(res)
            //    Console.WriteLine("PAid");
            var res = police.GenerateReport("SHP002");
            if(res!=null)
            {
                Console.WriteLine("Offence No.:"+res.OffenceNo);
                Console.WriteLine("Vehicle No.:"+res.VehNo);
                Console.WriteLine("Offence Id.:"+res.OffenceId);
                Console.WriteLine("Place      :"+res.Place);
                Console.WriteLine("Time       :"+res.Time);
                Console.WriteLine("Reported By:"+res.ReportedBy);
                Console.WriteLine("Status     :"+res.Status);
            }
        }
    }
}
