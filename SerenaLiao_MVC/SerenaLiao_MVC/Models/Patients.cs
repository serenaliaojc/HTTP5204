using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerenaLiao_MVC.Models
{
    [Table("sjghel_patients")]
    public class Patients
    {
        [Key]
        public int Patient_Id { get; set; }

        [Required]
        public string Patient_Email { get; set; }

        [Required]
        public string Patient_Password { get; set; }

        [Required]
        public string Patient_First_Name { get; set; }

        [Required]
        public string Patient_Last_Name { get; set; }

        [Required]
        public DateTime Patient_Date_Of_Birth { get; set; }

        [Required]
        public string Patient_Gender { get; set; }

        [Required]
        public string Patient_Phone { get; set; }

        [Required]
        public string Patient_Address { get; set; }

        [Required]
        public string Patient_PostCode { get; set; }
    }
}