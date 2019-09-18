using System;
using System.Collections.Generic;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop.View
{
    public partial class ProductPage : ContentPage
    {
        private ProductViewModel vm = new ProductViewModel();

        public ProductPage(string keyword, int userId)
        {
            InitializeComponent();
            vm.FetchByKeywordAsync(keyword);
            BindingContext = vm;
        }

        public ProductPage(int catId,int userId) 
        {
            InitializeComponent();
            vm.FetchByCategoryAsync(catId);
            BindingContext = vm;
        }

        public async void OnItemSelected(object o, ItemTappedEventArgs e)
        {
            var item = e.Item as Model.Product;
            await Navigation.PushAsync(new ProductDetail(item));
        }

    }
}
