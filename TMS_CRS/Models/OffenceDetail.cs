using System;
using System.Collections.Generic;

#nullable disable

namespace TMS_CRS.Models
{
    public partial class OffenceDetail
    {
        public string VehNo { get; set; }
        public DateTime Time { get; set; }
        public string Place { get; set; }
        public int? OffenceId { get; set; }
        public string ReportedBy { get; set; }
        public string Status { get; set; }

        public virtual TmOffence Offence { get; set; }
        public virtual TmRegdetail VehNoNavigation { get; set; }
    }
}
