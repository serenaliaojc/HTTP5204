using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC0208.Models; //include the models directory

namespace MVC0208.Controllers
{
    public class HomeController : Controller
    {
        GeoContext db = new GeoContext();

        // GET: Home
        public string Index()
        {
            return "You are in the controller viewing the Index action";
            //return View();
        }

        //root/home/details
        public string Details()
        {
            return "You are in the HomeController viewing the Details action.";
        }

        //action to retreive countries and cities based on form input
        //FormCollection: grab values from html based on the names
        public PartialViewResult Countries_Cities_Search(FormCollection form)
        {
            string search_term = form["term"]; // <input name="term">
            ViewCountriesCities countriesCities = new ViewCountriesCities();

            if (!string.IsNullOrWhiteSpace(search_term))
            {
                countriesCities.Countries = db.Countries.Where(ctries => ctries.Name.ToUpper().Contains(search_term.ToUpper())).ToList();
                countriesCities.Cities = db.Cities.Where(ctries => ctries.Name.ToUpper().Contains(search_term.ToUpper())).ToList();
            }
            return PartialView("~/Views/Home/_Search_Results.cshtml", countriesCities);
        }
    }
}