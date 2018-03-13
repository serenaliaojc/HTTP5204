using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC0208.Models;

namespace MVC0208.Controllers
{
    public class CountryController : Controller
    {
        GeoContext db = new GeoContext();

        // GET: Country
        // [site.com]/Country/Index
        public string Index()
        {
            return "This is the index action of the Country controller.";
        }

        public string AnotherAction()
        {
            return "Another action from the Country controller.";
        }

        public ActionResult GetView()
        {
            List<Country> countries = db.Countries.ToList();
            List<City> cities = db.Cities.ToList();

            //View model holding the above results
            ViewCountriesCities coutriesCities = new ViewCountriesCities();
            coutriesCities.Countries = countries;
            coutriesCities.Cities = cities;

            return View(coutriesCities);
        }
    }
}