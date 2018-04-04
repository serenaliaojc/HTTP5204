using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using anythingProject.Models;

namespace anythingProject.Controllers
{
    public class sjghel_patientsController : Controller
    {
        private ExampleEntities db = new ExampleEntities();

        // GET: sjghel_patients
        public ActionResult Index()
        {
            return View(db.sjghel_patients.ToList());
        }

        // GET: sjghel_patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sjghel_patients sjghel_patients = db.sjghel_patients.Find(id);
            if (sjghel_patients == null)
            {
                return HttpNotFound();
            }
            return View(sjghel_patients);
        }

        // GET: sjghel_patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sjghel_patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "patient_id,patient_email,patient_password,patient_first_name,patient_last_name,patient_date_of_birth,patient_gender,patient_phone,patient_address,patient_postcode")] sjghel_patients sjghel_patients)
        {
            if (ModelState.IsValid)
            {
                db.sjghel_patients.Add(sjghel_patients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sjghel_patients);
        }

        // GET: sjghel_patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sjghel_patients sjghel_patients = db.sjghel_patients.Find(id);
            if (sjghel_patients == null)
            {
                return HttpNotFound();
            }
            return View(sjghel_patients);
        }

        // POST: sjghel_patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "patient_id,patient_email,patient_password,patient_first_name,patient_last_name,patient_date_of_birth,patient_gender,patient_phone,patient_address,patient_postcode")] sjghel_patients sjghel_patients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sjghel_patients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sjghel_patients);
        }

        // GET: sjghel_patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sjghel_patients sjghel_patients = db.sjghel_patients.Find(id);
            if (sjghel_patients == null)
            {
                return HttpNotFound();
            }
            return View(sjghel_patients);
        }

        // POST: sjghel_patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sjghel_patients sjghel_patients = db.sjghel_patients.Find(id);
            db.sjghel_patients.Remove(sjghel_patients);
            db.SaveChanges();
            return RedirectToAction("Index");
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
