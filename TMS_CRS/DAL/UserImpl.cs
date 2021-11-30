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
        public UserImpl()
        {
            db = new TMSDBContext();
        }
        public UserImpl(TMSDBContext db)
        {
            this.db = db;
        }
        public bool AddUser(TmUsermaster user)
        {
            db.TmUsermasters.Add(user);
            var res = db.SaveChanges();
            if (res == 1)
                return true;
            return false;
        }

        public TmUsermaster UserLogin(string uname, string password)
        {
            var role = (from u in db.TmUsermasters
                        where (u.Username == uname && u.Password == password)
                        select u).SingleOrDefault();
            return role;
        }
    }
}
