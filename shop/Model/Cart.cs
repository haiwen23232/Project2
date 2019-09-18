﻿using System;
using System.Collections.Generic;

namespace shop.Model
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Cart()
        {
        }
    }
}
