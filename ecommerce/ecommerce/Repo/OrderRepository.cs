using ecommerce.Models.EF;
using ecommerce.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce.Repo
{
    public class OrderRepository
    {
        static Entities db;
        static OrderRepository() {
            db = new Entities();
        }

        public static void PlaceOrder(List<ProductModel> products,int cId) {
            Order o = new Order();
            o.CustomerId = cId;
            o.Status = "Ordered";
            db.Orders.Add(o);
            db.SaveChanges();
            foreach (var p in products) {
                var od = new Orderdetail()
                {
                    ProductId = p.Id,
                    Unitprice = p.Price,
                    Qty= 1,
                    OrderId = o.Id
                };
                db.Orderdetails.Add(od);
                db.SaveChanges();
            }

        }
        public static List<Order> MyOrders(int id) {
            var orders = from e in db.Orders
                         where e.CustomerId == id
                         select e;
            return orders.ToList();
        }
    }
}