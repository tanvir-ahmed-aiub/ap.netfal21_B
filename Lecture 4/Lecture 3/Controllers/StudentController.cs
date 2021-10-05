using Lecture_3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Lecture_3.Models;
using Lecture_3.Auth;

namespace Lecture_3.Controllers
{
    [AdminAccess]
    public class StudentController : Controller
    {
        // GET: Student
        [AllowAnonymous]
        public ActionResult Index()
        {
            Database db = new Database();
            var students = db.Students.Get();
            return View(students);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            Student s = new Student();
            return View(s);
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid) {
                Database db = new Database();
                db.Students.Create(s);
                return RedirectToAction("Index");
            }
            return View(s);
        }
        [HttpGet]
        public ActionResult Edit(int id) {
            Database db = new Database();
            var s = db.Students.Get(id);
            return View(s);
        }

    }

}