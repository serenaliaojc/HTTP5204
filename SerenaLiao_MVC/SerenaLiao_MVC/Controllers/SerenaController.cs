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
            return View();
        }
    }
}