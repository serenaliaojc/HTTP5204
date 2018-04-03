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
    public class sjghel_doctorsController : Controller
    {
        private ExampleEntities db = new ExampleEntities();

        // GET: sjghel_doctors
        public ActionResult Index()
        {
            return View(db.sjghel_doctors.ToList());
        }

        // GET: sjghel_doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sjghel_doctors sjghel_doctors = db.sjghel_doctors.Find(id);
            if (sjghel_doctors == null)
            {
                return HttpNotFound();
            }
            return View(sjghel_doctors);
        }

        // GET: sjghel_doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sjghel_doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "doctor_id,doctor_name")] sjghel_doctors sjghel_doctors)
        {
            if (ModelState.IsValid)
            {
                db.sjghel_doctors.Add(sjghel_doctors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sjghel_doctors);
        }

        // GET: sjghel_doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sjghel_doctors sjghel_doctors = db.sjghel_doctors.Find(id);
            if (sjghel_doctors == null)
            {
                return HttpNotFound();
            }
            return View(sjghel_doctors);
        }

        // POST: sjghel_doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "doctor_id,doctor_name")] sjghel_doctors sjghel_doctors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sjghel_doctors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sjghel_doctors);
        }

        // GET: sjghel_doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sjghel_doctors sjghel_doctors = db.sjghel_doctors.Find(id);
            if (sjghel_doctors == null)
            {
                return HttpNotFound();
            }
            return View(sjghel_doctors);
        }

        // POST: sjghel_doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sjghel_doctors sjghel_doctors = db.sjghel_doctors.Find(id);
            db.sjghel_doctors.Remove(sjghel_doctors);
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
