using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMSSajib.Models
{
    public class login
    {
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "UserName")]
        public String fUName { get; set; }
        [Required(ErrorMessage = "Field Required")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public String fNPassword { get; set; }
    }
}
