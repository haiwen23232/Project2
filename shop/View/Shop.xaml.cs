using System;
using System.Collections.Generic;
using shop.ViewModel;
using Xamarin.Forms;

namespace shop.View
{
    public partial class Shop : ContentPage
    {
        private SearchHistoryViewModel vm;

        public Shop()
        {
            InitializeComponent();
            vm = new SearchHistoryViewModel();
            this.HistoryListView.ItemsSource = vm.histories;
        }

        private void Search(object o, System.EventArgs e)
        {
            DisplayAlert("Search","Click","Ok");
        }
    }
}