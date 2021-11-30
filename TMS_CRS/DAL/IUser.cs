using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_CRS.Models;
using TMS_CRS;

namespace TMS_CRS.DAL
{
    public interface IUser
    {
        bool AddUser(TmUsermaster user);
        TmUsermaster UserLogin(string uname, string password);
    }
}
