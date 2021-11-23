using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_CRS.Models;
using TMS_CRS.DAL;

namespace TMS_CRS.DAL
{
    public class RTOImpl : IRTO
    {
        readonly TMSDBContext db;
        public RTOImpl(TMSDBContext db)
        {
            this.db = db;
        }

        public int AddOwner(TmOwnerdetail o)
        {
            db.TmOwnerdetails.Add(o);
            var res = db.SaveChanges();
            if (res == 1)
                return db.TmOwnerdetails.Max(x => x.OwnerId);
            else
                return 0;
        }

        public int AddVechile(TmVehicledetail v)
        {
            db.TmVehicledetails.Add(v);
            var res = db.SaveChanges();
            if (res == 1)
                return db.TmVehicledetails.Max(x => x.VehId);
            else
                return 0;
        }
        /*
        public List<TmOwnerdetail> GenerateReport()
        {
            
        }
        */
        public int Registration(TmRegdetail r)
        {
            db.TmRegdetails.Add(r);
            var res = db.SaveChanges();
            if (res == 1)
                return int.Parse(db.TmRegdetails.Max(x => x.AppNo));
            else
                return 0;
        }

        public bool Transferdetails(TmRegdetail newval, int vehId)
        {
            var olddata = db.TmRegdetails.Where(x => x.VehId == vehId).FirstOrDefault();
            olddata.OldOwnerId = newval.OldOwnerId;
            olddata.OwnerId = newval.OwnerId;
            olddata.OldOwner = newval.OldOwner;
            olddata.Owner = newval.Owner;
            var res = db.SaveChanges();
            if (res == 1)
                return true;
            else
                return false;
        }
    }
}
