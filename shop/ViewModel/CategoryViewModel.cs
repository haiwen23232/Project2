using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using shop.Data;
using shop.Model;

namespace shop.ViewModel
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        CategoriesManager categoriesManager = new CategoriesManager();
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Category> _categoriesList;

        public ObservableCollection<Category> CategoriesList
        {
            get { return _categoriesList; }
            set
            {
                _categoriesList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CategoriesList"));
                }
            }
        }

        public async Task FetchDataAsync()
        {
            var list = await categoriesManager.FetchCategoriesAsync();
            CategoriesList = new ObservableCollection<Category>(list);
        }

        public CategoryViewModel()
        {
            FetchDataAsync();
        }

    }
}
