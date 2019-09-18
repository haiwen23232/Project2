using System;
using System.Collections.Generic;
using shop.Model;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop.View
{
    public partial class Shop : ContentPage
    {
        private SearchHistoryViewModel vm;
        private int userId;

        public Shop(int userId)
        {
            InitializeComponent();
            vm = new SearchHistoryViewModel();
            this.HistoryListView.ItemsSource = vm.histories;
            this.userId = userId;
        }

        private async void Search(object o, System.EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage(SearchBar.Text,userId));
        }

        private async void SearchByHistory(object o,ItemTappedEventArgs e)
        {
            var item = e.Item as SearchHistory;
            await Navigation.PushAsync(new ProductPage(item.History, userId));
        }
    }
}