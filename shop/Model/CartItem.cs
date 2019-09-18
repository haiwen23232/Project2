using System;
using System.Collections.Generic;

namespace shop.Model
{
    public class CartItem
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public string Item { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public CartItem()
        {
            
        }
    }
}
