using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TMS_CRS.Models
{
    public partial class TmUsermaster
    {
        [Required(ErrorMessage = "Username is Needed")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be empty!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Rolename cannot be empty!")]
        public string Rolename { get; set; }

    }
    
}
