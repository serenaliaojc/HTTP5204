using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImageRepo.Models;
using System.IO;

namespace ImageRepo.Controllers
{
    public class Images_TableController : Controller
    {
        private Entities db = new Entities();

        // GET: Images_Table
        public ActionResult Index()
        {
            return View(db.Images_Table.ToList());
        }

        // GET: Images_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Images_Table images_Table = db.Images_Table.Find(id);
            if (images_Table == null)
            {
                return HttpNotFound();
            }
            return View(images_Table);
        }

        // GET: Images_Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Images_Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Img_Filename,Caption_Text")] Images_Table images_Table, HttpPostedFile file)
        {
            if (ModelState.IsValid)
            {
                if(file.ContentLength > 0)
                {
                    //get filename of the file
                    string filename = Path.GetFileName(file.FileName);

                    //find the path in the server to store the images
                    //add an unique directory for this image
                    string pathToUpload = Path.Combine(Server.MapPath("~/Images/" + images_Table.Id.ToString() + "/"));

                    //create the subdirectory
                    Directory.CreateDirectory(pathToUpload);

                    //save a copy of the file on the server
                    string filePathOnServer = Path.Combine(Server.MapPath("~/Images/" + images_Table.Id.ToString() + "/"), filename);
                    file.SaveAs(filePathOnServer);

                    //store filename result in model property
                    images_Table.Img_Filename = filename;

                    db.Images_Table.Add(images_Table);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(images_Table);
        }

        // GET: Images_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Images_Table images_Table = db.Images_Table.Find(id);
            if (images_Table == null)
            {
                return HttpNotFound();
            }
            return View(images_Table);
        }

        // POST: Images_Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Img_Filename,Caption_Text")] Images_Table images_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(images_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(images_Table);
        }

        // GET: Images_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Images_Table images_Table = db.Images_Table.Find(id);
            if (images_Table == null)
            {
                return HttpNotFound();
            }
            return View(images_Table);
        }

        // POST: Images_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Images_Table images_Table = db.Images_Table.Find(id);
            db.Images_Table.Remove(images_Table);
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
