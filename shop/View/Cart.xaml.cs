using System;
using System.Collections.Generic;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop.View
{
    public partial class Cart : ContentPage
    {
        private CartViewModel vm;
        public Cart()
        {
            InitializeComponent();
            vm = new CartViewModel();
            this.CartListView.ItemsSource = vm.carts;
        }
    }
}
