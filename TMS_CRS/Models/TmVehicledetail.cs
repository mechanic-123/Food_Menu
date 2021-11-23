using System;
using System.Collections.Generic;

#nullable disable

namespace TMS_CRS.Models
{
    public partial class TmVehicledetail
    {
        public TmVehicledetail()
        {
            TmRegdetails = new HashSet<TmRegdetail>();
        }

        public int VehId { get; set; }
        public string VehType { get; set; }
        public string EngineNo { get; set; }
        public string ModelNo { get; set; }
        public string VehName { get; set; }
        public string VehColor { get; set; }
        public string ManufacturerName { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public string Status { get; set; }
        public int? NoOfCyclinders { get; set; }
        public int? CuibicCapacity { get; set; }
        public string FuelUsed { get; set; }

        public virtual ICollection<TmRegdetail> TmRegdetails { get; set; }
    }
}
