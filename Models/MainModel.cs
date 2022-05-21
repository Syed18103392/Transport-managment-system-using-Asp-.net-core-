using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMSSajib.Models
{
    public class MainModel
    {
        public RegistrationFacultyInfo fi { get; set; }
        public AdminInfo ai { get; set; }
        public login lf { get; set; }
        public bool loginAleart {get;set;}
        public string RegistrationAleart { get; set; }
    }
}
