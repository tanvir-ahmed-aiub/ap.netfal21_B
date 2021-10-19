using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORM.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            var db = new UMSEntities();
            var data = db.Departments.ToList();
            return View(data);
        }
        public ActionResult Details(int Id) {
            var db = new UMSEntities();
            var data = (from d in db.Departments
                        where d.Id == Id
                        select d).FirstOrDefault();
            return View(data);
        }
    }
}