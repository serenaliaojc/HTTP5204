using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerenaLiao_MVC.Models
{
    [Table("sjghel_appointments")]
    public class Appointments
    {
        [Key]
        public int Appointment_Id { get; set; }
        public string Doctor_Id { get; set; }
        public int Patient_Id { get; set; }
        public DateTime Appointment_Time { get; set; }
        public string Appointment_Location { get; set; }
        public string Appointment_Status { get; set; }
    }
}