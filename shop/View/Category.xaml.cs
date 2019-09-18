using System;
using System.Collections.Generic;
using System.Diagnostics;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop.View
{
    public partial class Category : ContentPage
    {
        private int userId;
        public Category(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        public async void OnItemSelected(object o, ItemTappedEventArgs e)
        {
            var item = e.Item as shop.Model.Category;
            await Navigation.PushAsync(new ProductPage(item.CategoryId,userId));
        }
    }
}
