using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC0208.Models
{
    public class GeoContext : DbContext
    {
        //properties that interact with a table in the database
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}