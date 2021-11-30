using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TMS_CRS.Models
{
    public partial class OffenceDetail
    {
        [Required(ErrorMessage ="Vehicle Number is Needed")]
        public string VehNo { get; set; }
        public DateTime Time { get; set; }
        [Required(ErrorMessage ="Place cannot be blank")]
        public string Place { get; set; }
        
        public int? OffenceId { get; set; }
        [Required(ErrorMessage ="Reported by cannot be blank")]
        public string ReportedBy { get; set; }
        [Required(ErrorMessage ="Status Filed is Needed")]
        public string Status { get; set; }
        [Key]
        public int OffenceNo { get; set; }

        public virtual TmOffence Offence { get; set; }
        public virtual TmRegdetail VehNoNavigation { get; set; }
    }
}
