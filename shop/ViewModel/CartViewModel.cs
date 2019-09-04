using System;
using System.Collections.Generic;
using shop.Model;

namespace shop.ViewModel
{
    public class CartViewModel
    {
        public List<Cart> carts;

        public CartViewModel()
        {
            this.carts = new Cart().GetCarts();
        }
    }
}
