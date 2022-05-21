using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMSSajib.Models
{
    public class AdminInfo
    {
        [Key]
        public string id { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "First Name")]
        public String aFName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Last Name")]
        public String aLName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "UserName")]
        public String aUName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public String aContactNumber { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String aEmail { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public String aNPassword { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Confirm Name")]
        [DataType(DataType.Password)]
        [Compare("aNPassword")]
        public String aCPassword { get; set; }

        
    }
}
