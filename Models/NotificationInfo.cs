using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMSSajib.Models
{
    public class NotificationInfo
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Field Required")]
        public String Nfrom { get; set; }
        public String NTo { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [DataType(DataType.Text)]
        public String NFor { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [DataType(DataType.MultilineText)]
        public String NDetails { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Current Status")]
        public String NStatus { get; set; }
        public string NComingDate { get; set; }
        public string NComingTime { get; set; }
        public string NHId { get; set; }
        public string extra1 { get; set; }
        public string extra2 { get; set; }
    }
}
