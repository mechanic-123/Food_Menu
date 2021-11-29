using System;
using System.Collections.Generic;

#nullable disable

namespace TMS_CRS.Models
{
    public partial class TmUsermaster
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rolename { get; set; }
    }
    public enum RoleName
    {
        RTO_Officer,
        Traffic_Police,
        Vehicle_Owner
    }
}
