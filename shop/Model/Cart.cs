using System;
using System.Collections.Generic;

namespace shop.Model
{
    public class Cart
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Img { get; set; }
        public string Description { get { return "Price: $" + this.Price + " Quantity: " + this.Quantity; } }

        public Cart()
        {
        }

        public List<Cart> GetCarts()
        {
            List<Cart> carts = new List<Cart>()
            {
                new Cart() { Item="Adidas Sneaker",Quantity = 2, Price = 89.99, Img="basket.png" },
                new Cart() { Item = "Nike Hoddie",Quantity = 1, Price = 79.99, Img="basket.png" },
                new Cart() { Item = "Puma T-Shirt",Quantity = 1, Price = 39.99, Img="basket.png" }
            };
            return carts;
        }
    }
}
