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
            this.userId = userId;
            vm = new SearchHistoryViewModel(userId);
            BindingContext = vm;
        }

        private async void Search(object o, System.EventArgs e)
        {
            await vm.AddHistory(new SearchHistory(SearchBar.Text, userId));
            await vm.FetchDataAsync(userId);
            this.HistoryListView.ItemsSource = vm.HistoryList;
            await Navigation.PushAsync(new ProductPage(SearchBar.Text,userId));
        }

        private async void SearchByHistory(object o, ItemTappedEventArgs e)
        {
            var item = e.Item as SearchHistory;
            await Navigation.PushAsync(new ProductPage(item.HistoryStr, userId));
        }

        private async void ClearAll(object o,System.EventArgs e)
        {
            await vm.DeleteByUser(userId);
        }

    }
}