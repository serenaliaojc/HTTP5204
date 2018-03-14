using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerenaLiao_MVC.Models;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace SerenaLiao_MVC.Controllers
{
    public class SerenaController : Controller
    {
        SjghelAppointments db = new SjghelAppointments();

        // GET: Serena
        public ActionResult Index()
        {
            try
            {
                List<Patients> patients = db.Patients.ToList();
                return View(patients);
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Errors/Error.cshtml");
        }

        [HttpGet]
        public ActionResult Add()
        {
            try
            {
                return View();
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }

            return View("~/Views/Errors/Error.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Patients patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(patient);
            }
            catch (DbUpdateException DbException) 
            {
                ViewBag.DbExceptionMessage = DbException.Message;
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException;
            }

            return View("~/Views/Errors/Error.cshtml");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            try
            {
                if (id == 0)
                {
                    return RedirectToAction("Index");
                }

                Patients patient = db.Patients.SingleOrDefault(p => p.Patient_Id == id);

                if (patient == null)
                {
                    return RedirectToAction("Index");
                }

                return View(patient);
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }

            return View("~/Views/Errors/Error.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Patients patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(patient).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(patient);
            }
            catch (DbUpdateException dbException) 
            {
                ViewBag.ErrorMessage = dbException.Message;
            }
            catch (SqlException sqlException)
            {
                ViewBag.SqlExceptionMessage = sqlException.Message;
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }

            return View("~/Views/Errors/Error.cshtml");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == 0)
                {
                    return RedirectToAction("Index");
                }

                Patients patient = db.Patients.SingleOrDefault(p => p.Patient_Id == id);

                if (patient == null)
                {
                    return RedirectToAction("Index");
                }

                return View(patient);
            }
            catch (SqlException sqlException)
            {
                ViewBag.SqlExceptionMessage = sqlException.Message;
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }

            return View("~/Views/Errors/Error.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FormCollection form)
        {
            try
            {
                int id = Convert.ToInt32(form["patient_id"]);
                Patients patient = db.Patients.Find(id);
                db.Entry(patient).State = System.Data.Entity.EntityState.Modified;
                db.Patients.Remove(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException dbException)
            {
                ViewBag.DbExceptionMessage = dbException.Message;
            }
            catch (SqlException sqlException)
            {
                ViewBag.SqlExceptionMessage = sqlException.Message;
            }
            catch (Exception genericException)
            {
                ViewBag.ExceptionMessage = genericException.Message;
            }

            return View("~/Views/Errors/Error.cshtml");
        }
    }
}