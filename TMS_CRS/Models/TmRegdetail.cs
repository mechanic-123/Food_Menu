using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TMS_CRS.Models
{
    public partial class TmRegdetail
    {
        public TmRegdetail()
        {
            OffenceDetails = new HashSet<OffenceDetail>();
        }
        [Required(ErrorMessage = "Please Enter Application Number")]
        public string AppNo { get; set; }
        [Required(ErrorMessage = "Please Enter Vehicle Number")]
        public string VehNo { get; set; }
        [Required(ErrorMessage = "Please Enter Vehicle ID")]
        public int? VehId { get; set; }
        [Required(ErrorMessage = "Please Enter Owner ID")]
        public int? OwnerId { get; set; }
        public int? OldOwnerId { get; set; }
        [Required(ErrorMessage = "Please Enter Date of Purchase")]
        public DateTime DateOfPurchase { get; set; }
        [Required(ErrorMessage = "Please Enter Distributer Name")]
        public string DistrubuterName { get; set; }

        public virtual TmOwnerdetail OldOwner { get; set; }
        public virtual TmOwnerdetail Owner { get; set; }
        public virtual TmVehicledetail Veh { get; set; }
        public virtual ICollection<OffenceDetail> OffenceDetails { get; set; }
    }
}
