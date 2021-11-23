using System;
using System.Collections.Generic;

#nullable disable

namespace TMS_CRS.Models
{
    public partial class TmRegdetail
    {
        public string AppNo { get; set; }
        public string VehNo { get; set; }
        public int? VehId { get; set; }
        public int? OwnerId { get; set; }
        public int? OldOwnerId { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string DistrubuterName { get; set; }

        public virtual TmOwnerdetail OldOwner { get; set; }
        public virtual TmOwnerdetail Owner { get; set; }
        public virtual TmVehicledetail Veh { get; set; }
    }
}
