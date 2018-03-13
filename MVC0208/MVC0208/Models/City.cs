using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC0208.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name of city")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A number is required here")]
        public int Population { get; set; }

        [Required(ErrorMessage = "A city  needs a mayor!")]
        public string Mayor { get; set; }

        [Display(Name = "Country")]
        //[EmailAddress(ErrorMessage = "not email")]
        public string Country_Code { get; set; }
    }
}