using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC0208.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public string Code { get; set; }
        public int Population { get; set; }
        public string Continent { get; set; }
        public string Name { get; set; }
        public DateTime? Established { get; set; }
    }
}