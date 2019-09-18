using System;
using System.Collections.Generic;
using shop.Model;
using Xamarin.Forms;

namespace shop.View
{
    public partial class ProductDetail : ContentPage
    {
        public Product product;
        public ProductDetail(Product product)
        {
            this.product = product;
            InitializeComponent();

            this.ProductName.Text = product.Name;
        }
    }
}
