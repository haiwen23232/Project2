using System;
namespace shop.Model
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Product product { get; set; }
        public int Quantity { get; set; }

        public ProductOrder()
        {
        }
    }
}
