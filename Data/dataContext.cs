using TransportMSSajib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMSSajib.Data
{
    public class dataContext:DbContext
    {
        public dataContext(DbContextOptions<dataContext> options) : base(options)
        {
        }
        public DbSet<AdminInfo> Admin_Info { get; set; }
        public DbSet<FacultyInfo> Faculty_Info { get; set; }
        public DbSet<RegistrationFacultyInfo> Registration_faculty { get; set; }
        public DbSet<NotificationInfo> Notifications { get; set; }
        public DbSet<TransportInfo> Transport { get; set; }
    }
}
