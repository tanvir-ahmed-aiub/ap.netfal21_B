using IntroAPI.Models.EF;
using IntroAPI.Models.VM;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;


namespace IntroAPI.Controllers
{
    
    public class ProductController : ApiController
    {
        [Route("api/product/names")]
        [HttpGet]
        public List<string> PNames()
        {
            Entities db = new Entities();
            var data = (from e in db.Products
                        select e.Name).ToList();
            return data;
        }
        [Route("api/product/names/{id}")]
        [HttpGet]
        public string PNames(int id)
        {
            Entities db = new Entities();
            var data = (from e in db.Products
                        where e.Id == id
                        select e.Name).FirstOrDefault();
            return data;
        }
        public List<ProductModel> Get()
        {
            Entities db = new Entities();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product,ProductModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ProductModel>>(db.Products.ToList());
            return data;


            /*foreach (var e in db.Products)
            {
                /*var p = new ProductModel() {
                    Id = e.Id,

                };
                data.Add(p);
                data.Add(new ProductModel() { Id = e.Id, Name = e.Name, Price = e.Price });
            }
            return data;*/
        }
        public void Post(ProductModel p)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductModel, Product>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Product>(p);
            Entities db = new Entities();
            db.Products.Add(data);
            db.SaveChanges();

        }
    }
}
