using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture_2.Models;

namespace Lecture_2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            ViewBag.Name = "Tanvir Ahmed";
            string[] names = new string[5];
            names[0] = "Tanvir";
            names[1] = "Sabbir";
            ViewBag.Names = names;
            return View();
        }
        public ActionResult Create() {      
            Student s1 = new Student() { 
                Id = "1223234",
                Name = "tanvir ahmed",
                Dob = "12.12.12"
            };
            return View(s1);
        }
        public ActionResult List() {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 10; i++) {
                Student s1 = new Student()
                {
                    Id = "1223"+(i+1),
                    Name = "tanvir ahmed",
                    Dob = "12.12.12"
                };
                students.Add(s1);
            }
            return View(students);

        }
        [HttpPost]
        public ActionResult CreateSubmit(Student s) {

            //using request class
            /*ViewBag.Name = Request["Name"].ToString();
            ViewBag.Id = Convert.ToString(Request["Id"]);*/
            //using FormCollection object
            /*ViewBag.Name = fc["Name"].ToString();
            ViewBag.Id = fc["Id"].ToString();*/
            //using direct variables
            /*ViewBag.Name = Name;
            ViewBag.Id = Id;*/

            return View(s);
        }
    }
}