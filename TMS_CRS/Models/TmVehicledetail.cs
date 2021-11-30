using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Please Enter Vehicle Type")]
        public string VehType { get; set; }
        [Required(ErrorMessage = "Please Enter Engine Number")]
        public string EngineNo { get; set; }
        [Required(ErrorMessage = "Please Enter Model Number")]
        public string ModelNo { get; set; }
        [Required(ErrorMessage = "Please Enter Vehicle Name")]
        public string VehName { get; set; }
        [Required(ErrorMessage = "Please Enter Vehicle Color")]
        public string VehColor { get; set; }
        [Required(ErrorMessage = "Please Enter Manufacturer Name")]
        public string ManufacturerName { get; set; }
        [Required(ErrorMessage = "Please Enter Date of Manufacturing")]
        public DateTime DateOfManufacture { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Please Enter Number of cylinders")]
        public int? NoOfCyclinders { get; set; }
        [Required(ErrorMessage = "Please Enter Cubic Capacity")]
        public int? CuibicCapacity { get; set; }
        [Required(ErrorMessage = "Please Enter Fuel Used")]
        public string FuelUsed { get; set; }

        public virtual ICollection<TmRegdetail> TmRegdetails { get; set; }
    }
}
