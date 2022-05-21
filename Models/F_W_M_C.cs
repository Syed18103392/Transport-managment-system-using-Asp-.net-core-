using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMSSajib.Models
{
    public class F_W_M_C
    {
        public IQueryable<NotificationInfo> Tf { get; set; }
        public IQueryable<TransportInfo> Tishow { get; set; }
        public IQueryable<TransportInfo> Tisearch { get; set; }
        public IQueryable<FacultyInfo> fishow { get; set; }
        public IQueryable<AdminInfo> Airetrive { get; set; }
        public TransportInfo Tiretrive { get; set; }
        public AdminInfo Aitakeinput { get; set; }
        public string rdate { get; set; }
        public string rpurpose { get; set; }

        public FacultyInfo fi { get; set; }
        public string oldpass { get; set; }
        public string txt { get; set; }

    }
}
