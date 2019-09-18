using System;
using System.Collections.Generic;

namespace shop.Model
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public String Payment { get; set; }
        public String Address { get; set; }
        public List<ProductOrder> ProductList { get; set; }

            public Order()
        {
        }
    }
}
