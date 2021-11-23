using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_CRS.Models;

namespace TMS_CRS.DAL
{
    public class UserImpl : IUser
    {
        readonly TMSDBContext db;
        public UserImpl(TMSDBContext db)
        {
            this.db = db;
        }
        public TmUsermaster AddUser(TmUsermaster user)
        {
            db.TmUsermasters.Add(user);
            var res = db.SaveChanges();
            if (res == 1)
                return user;
            return null;
        }
    }
}
