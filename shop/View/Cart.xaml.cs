using System;
using System.Collections.Generic;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop.View
{
    public partial class Cart : ContentPage
    {
        private CartViewModel vm;

        public Cart(int userId)
        {
            InitializeComponent();
            vm = new CartViewModel();
            vm.FetcyByUserAsync(userId);
            BindingContext = vm;
        }
    }
}
