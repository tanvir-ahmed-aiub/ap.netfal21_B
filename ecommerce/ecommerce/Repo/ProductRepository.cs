using ecommerce.Models.EF;
using ecommerce.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce.Repo
{
    public class ProductRepository
    {
        static Entities db;
        static ProductRepository() {
            db = new Entities();
        }
        public static ProductModel Get(int id) {
            var p = (from pr in db.Products
                     where pr.Id == id
                     select pr).FirstOrDefault();
            /*return new ProductModel() { 
                Id= p.Id,
                Name = p.Name,
                Price = p.Price
            };*/
            ProductModel pm = new ProductModel()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            };
            return pm;


        }
        public static List<ProductModel> GetAll() {
            var products = new List<ProductModel>();
            foreach (var p in db.Products) {
                ProductModel pm = new ProductModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                };
                products.Add(pm);
            }
            return products;
        }
    }
}