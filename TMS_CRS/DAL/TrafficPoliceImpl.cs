using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_CRS.DAL;
using TMS_CRS.Models;

namespace TMS_CRS.DAL
{
    public class TrafficPoliceImpl:ITrafficPolice
    {
        TMSDBContext db = new TMSDBContext();
        //traffic police can add penalty 
        public int  Addpenalty(TmOffence o)
        {
            db.TmOffences.Add(o);
            var res = db.SaveChanges();
            if (res == 1)
                return (int) db.OffenceDetails.Max(x=>x.OffenceId);
            return 0;
        }
        //traffic police can edit penalty status once the user pay penalty
        public bool EditPenalty(OffenceDetail newval,string vno)
        {
            var oldval = db.OffenceDetails.Where(x => x.VehNo == vno).FirstOrDefault();
            oldval.Status = newval.Status;
            db.Update(oldval);
            var res = db.SaveChanges();
            if (res == 1)
                return true;
            return false;
        }
        //traffic police can generate a report by using vehno
        public OffenceDetail GenerateReport(string vno)
        {
            return db.OffenceDetails.Where(x => x.VehNo == vno).FirstOrDefault();
                
        }
    }
}
