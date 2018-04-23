using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sjghel_Project.Models;
using System.Web.Security;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Sjghel_Project.Controllers
{
    public class AdminsController : Controller
    {
        private HospitalEntities db = new HospitalEntities();

        // GET: Admins
        [Authorize(Roles = "grand_admin, news_editor")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "grand_admin")]
        public ActionResult AdminList()
        {
            try
            {
                return View(db.Admins.ToList());
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin admin)
        {
            try
            {
                admin.admin_password = Encryptor.MD5Encrptor(admin.admin_password);

                int count = db.Admins.Where(u => u.admin_name == admin.admin_name && u.admin_password == admin.admin_password).Count();

                if (count == 1)
                {
                    FormsAuthentication.SetAuthCookie(admin.admin_name, false);
                    return RedirectToAction("Index");
                }

                ViewBag.Message = "Invalid username and/or password";
                return View(admin);
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: Admins/Details/5
        [Authorize(Roles = "grand_admin")]
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Admin admin = db.Admins.Find(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                return View(admin);
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        // GET: Admins/Create
        [Authorize(Roles = "grand_admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "grand_admin")]
        public ActionResult Create([Bind(Include = "admin_id,admin_name,admin_password,admin_role")] Admin admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Admins.Add(admin);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(admin);
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        // GET: Admins/Edit/5
        [Authorize(Roles = "grand_admin")]
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Admin admin = db.Admins.Find(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                return View(admin);
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");

        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "grand_admin")]
        public ActionResult Edit([Bind(Include = "admin_id,admin_name,admin_password,admin_role")] Admin admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(admin).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(admin);
            }
            catch (DbUpdateException DbException)
            {
                ViewBag.DbExceptionMessage = ErrorHandler.DbUpdateHandler(DbException);
            }
            catch (SqlException sqlException)
            {
                ViewBag.SqlExceptionMessage = sqlException.Message;
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        // GET: Admins/Delete/5
        [Authorize(Roles = "grand_admin")]
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Admin admin = db.Admins.Find(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                return View(admin);
            }
            catch (DbUpdateException DbException)
            {
                ViewBag.DbExceptionMessage = ErrorHandler.DbUpdateHandler(DbException);
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "grand_admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Admin admin = db.Admins.Find(id);
                db.Admins.Remove(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException DbException)
            {
                TempData["DbExceptionMessage"] = "Cannot delete: " + ErrorHandler.DbUpdateHandler(DbException);
            }
            catch (SqlException sqlException)
            {
                TempData["SqlExceptionMessage"] = sqlException.Message;
            }
            catch (Exception genericException)
            {
                TempData["ExceptionMessage"] = genericException.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
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
