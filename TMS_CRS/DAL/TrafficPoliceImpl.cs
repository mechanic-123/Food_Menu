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
        readonly TMSDBContext db; 
        public TrafficPoliceImpl()
        {
            db = new TMSDBContext();
        }
        public TrafficPoliceImpl(TMSDBContext db)
        {
            this.db = db;
        }
        //traffic police can add penalty 
        public int  Addpenalty(OffenceDetail od)
        {
            db.OffenceDetails.Add(od);
            var res = db.SaveChanges();
            if (res == 1)
                return 1;
            return 0;
        }
        //traffic police can edit penalty status once the user pay penalty
        public bool EditPenalty(OffenceDetail newval,int ono)
        {
            var oldval = db.OffenceDetails.Where(x => x.OffenceNo == ono).FirstOrDefault();
            oldval.Status = newval.Status;
            db.Update(oldval);
            var res = db.SaveChanges();
            if (res == 1)
                return true;
            return false;
        }

        public OffenceDetail GetoffencebyOffno(int ono)
        {
            return db.OffenceDetails.Where(x=>x.OffenceNo==ono).FirstOrDefault();
        }

        public List<OffenceDetail> Showalloffence()
        {
            return db.OffenceDetails.ToList();
        }

        //traffic police can generate a report by using vehno
        //public offencedetail generatereport(string vno)
        //{
        //    return db.offencedetails.where(x => x.vehno == vno).firstordefault();

        //}

        List<OffenceDetail> ITrafficPolice.GenerateReport(string vno)
        {
            return db.OffenceDetails.Where(x => x.VehNo == vno).ToList();
        }
    }
}
