using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC0208.Models;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace MVC0208.Controllers
{
    public class CitiesController : Controller
    {
        GeoContext db = new GeoContext();

        // GET: Cities
        public ActionResult Index()
        {
            //Display all cities
            List<City> cities = db.Cities.ToList();

            return View(cities);
        }

        // GET: Add form
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        // POST: Add form
        [HttpPost]
        public ActionResult Add(City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(city);
        }

        //GET: Update
        [HttpGet]
        public ActionResult Update(int? id) // id find in url
        {
            City city = db.Cities.SingleOrDefault(model => model.Id == id);
            return View();
        }

        //POST: Upadate
        [HttpPost]
        public ActionResult Update(City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(city);
        }

        //Delete
        public ActionResult Delete(int id)
        {
            try
            {
                City city = db.Cities.SingleOrDefault(cty => cty.Id == id);
                return View("~/Views/Cities/Delete.cshtml", city);
            }
            catch (DbUpdateException DbException)
            {
                ViewBag.ErrorMessage = DbException.Message;
            }
            catch (SqlException sqlException)
            {
                ViewBag.ErrorMessage += " " + sqlException.Message;
            }
            catch (Exception gennericException)
            {
                ViewBag.ErrorMessage += " " + gennericException.Message;
            }
            
            //db.Cities.Remove(city);
            //db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Cities/DeleteThis/(int)
        public ActionResult DeleteThis(int id)
        {
            try
            {
                City city = db.Cities.SingleOrDefault(cty => cty.Id == id);
                db.Cities.Remove(city);
                db.SaveChanges();
            }
            catch (Exception gennericException)
            {
                ViewBag.ErrorMessage += " " + gennericException.Message;
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult Cities()
        {
            return PartialView("~/Views/Cities/_Cities.cshtml", db.Cities.ToList());
        }
    }
}