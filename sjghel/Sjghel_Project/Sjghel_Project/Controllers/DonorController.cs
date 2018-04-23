using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sjghel_Project.Models;

namespace Sjghel_Project.Controllers
{
    public class DonorController : Controller
    {
        private HospitalEntities db = new HospitalEntities();

        // GET: Donors
        [Authorize(Roles = "grand_admin")]
        public ActionResult Index()
        {            
            try
            {
                return View(db.Donors.ToList());
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");

        }

        // GET: Donors/Details/5
        [Authorize(Roles = "grand_admin")]
        public ActionResult Details(int? id)
        {            
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Donor Donors = db.Donors.Find(id);
                if (Donors == null)
                {
                    return HttpNotFound();
                }
                return View(Donors);
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        // GET: Donors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,First_Name,Last_Name,Address,City,Province,Postal_Code,Country")] Donor Donors)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    db.Donors.Add(Donors);
                    db.SaveChanges();
                    return RedirectToAction("Create", "Donation");
                }

                return View(Donors);
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        // GET: Donors/Edit/5
        [Authorize(Roles = "grand_admin")]
        public ActionResult Edit(int? id)
        {            
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Donor Donors = db.Donors.Find(id);
                if (Donors == null)
                {
                    return HttpNotFound();
                }
                return View(Donors);
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "grand_admin")]
        public ActionResult Edit([Bind(Include = "Id,Email,First_Name,Last_Name,Address,City,Province,Postal_Code,Country")] Donor Donors)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Donors).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(Donors);
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        // GET: Donors/Delete/5
        [Authorize(Roles = "grand_admin")]
        public ActionResult Delete(int? id)
        {            
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Donor Donors = db.Donors.Find(id);
                if (Donors == null)
                {
                    return HttpNotFound();
                }
                return View(Donors);
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "grand_admin")]
        public ActionResult DeleteConfirmed(int id)
        {            
            try
            {
                Donor Donors = db.Donors.Find(id);
                List<Donation> Donations = db.Donations.Where(d => d.Donor_Id == id).ToList();
                db.Donations.RemoveRange(Donations);
                db.Donors.Remove(Donors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
