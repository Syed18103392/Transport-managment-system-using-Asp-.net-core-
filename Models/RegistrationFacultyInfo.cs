using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMSSajib.Models
{
    public class RegistrationFacultyInfo
    {
        [Key]
        public string id { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "First Name")]
        public String fFName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Last Name")]
        public String fLName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "UserName")]
        public String fUName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Designation")]
        public String fDesignation { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public String fContactNumber { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String fEmail { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public String fNPassword { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "Confirm Name")]
        [DataType(DataType.Password)]
        [Compare("fNPassword")]
        public String fCPassword { get; set; }

    }
}
