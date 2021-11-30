using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TMS_CRS.Models
{
    public partial class TmOwnerdetail
    {
        public TmOwnerdetail()
        {
            TmRegdetailOldOwners = new HashSet<TmRegdetail>();
            TmRegdetailOwners = new HashSet<TmRegdetail>();
        }

        public int OwnerId { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string Lname { get; set; }
        [Required(ErrorMessage = "Please enter date of birth")]
        public DateTime Dateofbirth { get; set; }
        [Required(ErrorMessage = "Please Enter landline number")]
        public long? LandlineNo { get; set; }
        [Required(ErrorMessage = "Please enter mobile number")]
        public long? MobileNo { get; set; }
        [Required(ErrorMessage = "Please select gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter Temperory Address")]
        public string TempAddr { get; set; }
        [Required(ErrorMessage = "Please Enter permanent Address")]
        public string PermAddr { get; set; }
        [Required(ErrorMessage = "Please Enter pincode")]
        public int Pincode { get; set; }
        [Required(ErrorMessage = "Please Enter occupation")]
        public string Occupation { get; set; }
        [Required(ErrorMessage = "Please Enter pancard number")]
        public string PancardNo { get; set; }
        [Required(ErrorMessage = "Please Enter Address Proof Name")]
        public string AddProofName { get; set; }

        public virtual ICollection<TmRegdetail> TmRegdetailOldOwners { get; set; }
        public virtual ICollection<TmRegdetail> TmRegdetailOwners { get; set; }
    }
}
