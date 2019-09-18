using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using shop.Data;
using shop.Model;

namespace shop.ViewModel
{
    public class ProductViewModel: INotifyPropertyChanged
    {
        ProductsManager productsManager = new ProductsManager();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Product> _productsList;

        public ObservableCollection<Product> ProductsList
        {
            get { return _productsList; }
            set
            {
                _productsList = value;
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductsList"));
            }
        }

        public async Task FetchByCategoryAsync(int catId)
        {
            var list = await productsManager.FetchProductsByCategoryAsync(catId);
            ProductsList = new ObservableCollection<Product>(list);
        }

        public async Task FetchByKeywordAsync(string keyword)
        {
            var list = await productsManager.FetchProductsByKeywordAsync(keyword);
            ProductsList = new ObservableCollection<Product>(list);
        }

        public ProductViewModel()
        {
        }
    }
}
