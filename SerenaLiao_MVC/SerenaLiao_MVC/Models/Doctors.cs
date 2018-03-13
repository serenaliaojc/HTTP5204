using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SerenaLiao_MVC.Models
{
    [Table("sjghel_doctors")]
    public class Doctors
    {
        [Key]
        public int Doctor_Id { get; set; }
        public string Doctor_Name { get; set; }
    }
}