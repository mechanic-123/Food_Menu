using System;
using System.Collections.Generic;

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
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime Dateofbirth { get; set; }
        public long? LandlineNo { get; set; }
        public long? MobileNo { get; set; }
        public string Gender { get; set; }
        public string TempAddr { get; set; }
        public string PermAddr { get; set; }
        public int Pincode { get; set; }
        public string Occupation { get; set; }
        public string PancardNo { get; set; }
        public string AddProofName { get; set; }

        public virtual ICollection<TmRegdetail> TmRegdetailOldOwners { get; set; }
        public virtual ICollection<TmRegdetail> TmRegdetailOwners { get; set; }
    }
}
