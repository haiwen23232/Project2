using System;
using System.Collections.Generic;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop.View
{
    public partial class Category : ContentPage
    {
        private CategoryViewModel vm;
        public Category()
        {
            InitializeComponent();
            vm = new CategoryViewModel();
            this.CategoryListView.ItemsSource = vm.categories;
        }
    }
}
