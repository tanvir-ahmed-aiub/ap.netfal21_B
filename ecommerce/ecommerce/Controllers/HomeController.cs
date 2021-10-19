using ecommerce.Models.VM;
using ecommerce.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ecommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var p = ProductRepository.GetAll();
            return View(p);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AddtoCart(int id) {
            var pm = ProductRepository.Get(id);
            List<ProductModel> products;
            if (Session["cart"] == null)
            {
                products = new List<ProductModel>();
            }
            else {
                var json = Session["cart"].ToString();
                products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);
            }

            products.Add(pm);
            var json2 = new JavaScriptSerializer().Serialize(products);
            Session["cart"] = json2;
            return RedirectToAction("Index");

        }
        public ActionResult Cart() {
            var json = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);
            return View(products);
        }
        public ActionResult Checkout() {
            var json = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>(json);
            var cid = 1; //User.Identity.Name
            OrderRepository.PlaceOrder(products, cid);
            Session.Remove("cart");
            return RedirectToAction("Index");

            
        }
        public ActionResult MyOrders() {
            var cid = 1; //User.Identity.Name
            var orders = OrderRepository.MyOrders(cid);
            return View(orders);

        }
    }
}