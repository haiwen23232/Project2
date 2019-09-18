using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using shop.Data;
using shop.Model;

namespace shop.ViewModel
{
    public class CartViewModel: INotifyPropertyChanged
    {
        CartsManager cartsManager = new CartsManager();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Cart> _cartsList;

        public ObservableCollection<Cart> CartsList
        {
            get { return _cartsList; }
            set
            {
                _cartsList = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CartsList"));
            }
        }

        public async Task FetcyByUserAsync(int userId)
        {
            var list = await cartsManager.FetchCartsByUserAsync(userId);
            CartsList = new ObservableCollection<Cart>(list);
        }

        public CartViewModel()
        { 
        }
    }
}
