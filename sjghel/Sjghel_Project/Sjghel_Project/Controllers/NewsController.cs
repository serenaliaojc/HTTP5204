using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sjghel_Project.Models;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;

namespace Sjghel_Project.Controllers
{
    public class NewsController : Controller
    {
        private HospitalEntities db = new HospitalEntities();

        // GET: News
        public ActionResult Index()
        {
            try
            {
                return View(db.News.ToList());
            }
            catch(Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        [HttpPost]
        public PartialViewResult Search(FormCollection form)
        {
            string search_term = form["term"];
            List<News> news = new List<News>();

            if (!String.IsNullOrWhiteSpace(search_term))
            {
                try
                {
                    news = db.News.Where(n => n.news_title.ToUpper().Contains(search_term.ToUpper())).ToList();
                }
                catch(Exception exception)
                {
                    ViewBag.ExceptionMessage = exception.Message;
                    return PartialView("~/Views/Shared/_Partial_Error.cshtml");
                }
            }

            return PartialView("~/Views/News/_Search_Result.cshtml", news);
        }

        [Authorize(Roles = "grand_admin, news_editor")]
        public ActionResult Admin()
        {
            try
            {
                return View(db.News.ToList());
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }
                News news = db.News.Find(id);
                news.news_content = news.news_content.Replace(Environment.NewLine, "<br />");
                if (news == null)
                {
                    //return HttpNotFound();
                    ViewBag.ExceptionMessage = "Sorry, cannot find the article.";
                    return View("~/Views/Shared/Error.cshtml");
                }
                return View(news);
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        // GET: News/Create
        [Authorize(Roles = "grand_admin, news_editor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "grand_admin, news_editor")]
        public ActionResult Create([Bind(Include = "news_id,news_post_time,news_edit_time,news_title,news_brief,news_content")] News news, HttpPostedFileBase news_pic)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string pic_default = "default.jpg";
                    news.news_pic_path = pic_default;
                    if (news_pic != null )
                    {
                        string imgName = Path.GetFileName(news_pic.FileName);
                        string filePathOnServer = Path.Combine(Server.MapPath("~/Images/News/"), imgName);
                        news_pic.SaveAs(filePathOnServer);
                        news.news_pic_path = imgName;
                    }
                    news.news_post_time = DateTime.Now;
                    news.news_edit_time = DateTime.Now;
                    db.News.Add(news);
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = news.news_id });
                }

                return View(news);
            }
            catch(Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        // GET: News/Edit/5
        [Authorize(Roles = "grand_admin, news_editor")]
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Admin");
                }
                News news = db.News.Find(id);
                if (news == null)
                {
                    ViewBag.ExceptionMessage = "Sorry, cannot find the article.";
                    return View("~/Views/Shared/Error.cshtml");
                }
                //TempData["NewsPic"] = news.news_pic_path;
                return View(news);
            }
            catch (Exception exception)
            {
                ViewBag.ExceptionMessage = exception.Message;
            }

            return View("~/Views/Shared/Error.cshtml");
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "grand_admin, news_editor")]
        public ActionResult Edit([Bind(Include = "news_id,news_post_time,news_edit_time,news_title,news_brief,news_content,news_pic_path")] News news, HttpPostedFileBase news_pic)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    if (news_pic != null)
                    {
                        string imgName = Path.GetFileName(news_pic.FileName);
                        string filePathOnServer = Path.Combine(Server.MapPath("~/Images/News/"), imgName);

                        //string pathToRemoveFile = Request.MapPath("~/Images/News/" + TempData["NewsPic"]);
                        //string pathToRemoveFile = Path.Combine(Server.MapPath("~/Images/News/" + TempData["NewsPic"]));
                        //System.IO.File.Delete(pathToRemoveFile);
                        if (news.news_pic_path != "default.jpg")
                        {
                            string pathToRemoveFile = Path.Combine(Server.MapPath("~/Images/News/"), news.news_pic_path);
                            System.IO.File.Delete(pathToRemoveFile);
                        }

                        news_pic.SaveAs(filePathOnServer);
                        news.news_pic_path = imgName;
                    } 
                    news.news_edit_time = DateTime.Now;
                    db.Entry(news).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = news.news_id });
                }
                return View(news);
            //}
            //catch (DbUpdateException DbException)
            //{
            //    ViewBag.DbExceptionMessage = ErrorHandler.DbUpdateHandler(DbException);
            //}
            //catch (SqlException sqlException)
            //{
            //    ViewBag.SqlExceptionMessage = sqlException.Message;
            //}
            //catch (Exception exception)
            //{
            //    ViewBag.ExceptionMessage = exception.Message;
            //}

            //return View("~/Views/Shared/Error.cshtml");
        }

        // GET: News/Delete/5
        [Authorize(Roles = "grand_admin, news_editor")]
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Admin");
                }
                News news = db.News.Find(id);
                if (news == null)
                {
                    ViewBag.ExceptionMessage = "Sorry, cannot delete the article.";
                    return View("~/Views/Shared/Error.cshtml");
                }
                return View(news);
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

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "grand_admin, news_editor")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                News news = db.News.Find(id);
                if (news.news_pic_path != "default.jpg")
                {
                    string pathToRemoveFile = Path.Combine(Server.MapPath("~/Images/News/"), news.news_pic_path);
                    System.IO.File.Delete(pathToRemoveFile);
                }
                db.News.Remove(news);
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            catch (DbUpdateException DbException)
            {
                //ViewBag only works when returning a view, not redirecting to actions. TempData can persist across Actions
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
