using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMSSajib.Models
{
    public class TransportInfo
    {
        [Key]
        [Required(ErrorMessage ="Filed Required")]
        [Display(Name ="Transport Number")]

        public string TransportNumber { get; set; }

        [Required(ErrorMessage = "Filed Required")]
        [Display(Name = "Transport Type")]
        public string TransportType { get; set; }

        [Required(ErrorMessage = "Filed Required")]
        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }
        [Required(ErrorMessage = "Filed Required")]
        [Display(Name = "Driver Number")]
        public string DriverNumber { get; set; }
        public string BookingDate { get; set; }
        public string hour { get; set; }
        public string Status { get; set; }
        public string route { get; set; }


    }
}
