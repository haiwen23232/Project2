using System;
using System.Collections.Generic;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop.View
{
    public partial class Cart : ContentPage
    {
        private CartViewModel vm;
        private string _total;

        public Cart(int userId)
        {
            InitializeComponent();
            vm = new CartViewModel();
            vm.FetcyByUserAsync(userId);
            _total = vm.TotalPrice(userId);
            BindingContext = vm;
            this.totalPrice.Text = "Total price: $ " + _total;
        }
    }
}
