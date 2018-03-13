using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SerenaLiao_MVC.Models
{
    public class SjghelAppointments: DbContext
    {
        public DbSet<Appointments> DoctorAppointments { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patients { get; set; }
    }
}