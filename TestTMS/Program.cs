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

            OffenceDetail off = new OffenceDetail();
            /*{
                VehNo = "SHP002",
                Time = DateTime.Now,
                Place = "Pari Chowk",
                OffenceId = 120,
                ReportedBy = "Karthik",
                Status = "NOT PAID"
             };
            var res = police.Addpenalty(off);
            if (res > 0)
                Console.WriteLine("Offence Added.");*/

            /* var res = police.EditPenalty(off, 4);
             if (res)
                 Console.WriteLine("Offence had be cleared");*/


            /*  var res = police.GenerateReport("SHP002");
              if (res != null)
              {
                  Console.WriteLine("Offence No.:" + res.OffenceNo);
                  Console.WriteLine("Vehicle No.:" + res.VehNo);
                  Console.WriteLine("Offence Id.:" + res.OffenceId);
                  Console.WriteLine("Place      :" + res.Place);
                  Console.WriteLine("Time       :" + res.Time);
                  Console.WriteLine("Reported By:" + res.ReportedBy);
                  Console.WriteLine("Status     :" + res.Status);
              }*/
            TmUsermaster user = new TmUsermaster
            {
                Username = "R",
                Rolename = "Police",
                Password = "oipi"
            };
            /*IUser u = new UserImpl();
            var res = u.AddUser(user);
            if (res)
                Console.WriteLine("User Added");

            Console.WriteLine("Registeration Done"); */
            /*IRTO rto = new RTOImpl();
            TmRegdetail reg = new TmRegdetail
            {
                AppNo = "REG002",
                VehNo = "SHP002",
                VehId = 10000,
                OwnerId = 1002,
                OldOwnerId = null,
                DateOfPurchase = DateTime.Today,
                DistrubuterName = "Bardocks"
            };
            var res = rto.Transferdetails(reg, 10000);
            if(res)
                Console.WriteLine("Transferred.");

            }*/
            IUser u = new UserImpl();
            var res = u.UserLogin("Alex", "Alex");
            if(res!=null)
                Console.WriteLine(res.ToString());
        }
    }
}
