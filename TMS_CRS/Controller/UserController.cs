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
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUser user;
        readonly TMSDBContext db;
        public UserController(IUser user, TMSDBContext db)
        {
            this.user = user;
            this.db = db;
        }
        [HttpPost]
        [Route("api/User/AddUser")]
        public bool Post(TmUsermaster u)
        {
            return user.AddUser(u);
        }
    }
}
