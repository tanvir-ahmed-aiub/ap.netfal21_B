using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerRepo : IRepository<Customer, int>
    {
        Entities db;
        public CustomerRepo(Entities db) {
            this.db = db;
        }
        public void Add(Customer e)
        {
            db.Customers.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var c = db.Customers.FirstOrDefault(e => e.Id == id);
            db.Customers.Remove(c);
        }

        public void Edit(Customer e)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.FirstOrDefault(e => e.Id == id);
        }
    }
}
