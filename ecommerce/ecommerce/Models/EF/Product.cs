//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ecommerce.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.Orderdetails = new HashSet<Orderdetail>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
