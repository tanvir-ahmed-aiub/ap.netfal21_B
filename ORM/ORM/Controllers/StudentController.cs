using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORM.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var db = new UMSEntities();// Database db = new Database()
            var data = db.Students.ToList();
            return View(data);
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s) {
            var db = new UMSEntities();
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}