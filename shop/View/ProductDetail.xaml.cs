using System;
using System.Collections.Generic;
using shop.Model;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop.View
{
    public partial class ProductDetail : ContentPage
    {
        public Product product;
        private int quantity;
        private int userId;

        public ProductDetail(Product product,int id)
        {
            this.product = product;
            this.userId = id;
            InitializeComponent();

            this.ProductName.Text = product.Name;
            this.ProductPrice.Text = "Price: $ " + product.Price;
        }

        public async void AddToCart(object o, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(this.quantityEntry.Text))
            {
                await DisplayAlert("Add to cart","Please enter quantity","Ok");
            }
            else
            {
                await DisplayAlert("Add to cart", "Success", "Ok");
                this.quantity = Int32.Parse(this.quantityEntry.Text);
                CartViewModel cvm = new CartViewModel();
                await cvm.CreateCart(new Model.Cart { ProductId = this.product.ProductId, Quantity = quantity, UserId = userId });
            }
            
        }
    }
}
