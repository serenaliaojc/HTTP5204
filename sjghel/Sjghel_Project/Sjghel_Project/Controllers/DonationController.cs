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
    public class DonationController : Controller
    {
        private HospitalEntities db = new HospitalEntities();

        // GET: Donation
        [Authorize(Roles = "grand_admin")]
        public ActionResult Index()
        {
            try
            {
                var Donations = db.Donations.Include(c => c.Donor);
                return View(Donations.ToList());
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Errors/Details.cshtml");
        }

        // GET: Donation/Details/5
        [Authorize(Roles = "grand_admin")]
        public ActionResult Details(int? id)
        {            
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Donation Donations = db.Donations.Find(id);
                if (Donations == null)
                {
                    return HttpNotFound();
                }
                return View(Donations);
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        // GET: Donation/Create
        public ActionResult Create()
        {            
            try
            {
                ViewBag.Donor_Id = new SelectList(db.Donors, "Id", "Email");
                return View();
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        // POST: Donation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Donation_Date,Donor_Id,Amount,Message,Payment_API,Payment_Method")] Donation Donations)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Donations.Donation_Date = DateTime.Now;
                    db.Donations.Add(Donations);
                    db.SaveChanges();
                    return RedirectToAction("Thanks", "Home");
                }

                ViewBag.Donor_Id = new SelectList(db.Donors, "Id", "Email", Donations.Donor_Id);
                return View(Donations);
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        // GET: Donation/Edit/5
        [Authorize(Roles = "grand_admin")]
        public ActionResult Edit(int? id)
        {            
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Donation Donations = db.Donations.Find(id);
                if (Donations == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Donor_Id = new SelectList(db.Donors, "Id", "Email", Donations.Donor_Id);
                return View(Donations);
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        // POST: Donation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "grand_admin")]
        public ActionResult Edit([Bind(Include = "Id,Donation_Date,Donor_Id,Amount,Message,Payment_API,Payment_Method")] Donation Donations)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Donations).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Donor_Id = new SelectList(db.Donors, "Id", "Email", Donations.Donor_Id);
                return View(Donations);
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        // GET: Donation/Delete/5
        [Authorize(Roles = "grand_admin")]
        public ActionResult Delete(int? id)
        {            
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Donation Donations = db.Donations.Find(id);
                if (Donations == null)
                {
                    return HttpNotFound();
                }
                return View(Donations);
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }
            return View("~/Views/Errors/Details.cshtml");
        }

        // POST: Donation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "grand_admin")]
        public ActionResult DeleteConfirmed(int id)
        {            
            try
            {
                Donation Donations = db.Donations.Find(id);
                db.Donations.Remove(Donations);
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
