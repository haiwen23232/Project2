using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using shop.Data;
using shop.Model;

namespace shop.ViewModel
{
    public class SearchHistoryViewModel : INotifyPropertyChanged 
    {
        HistoryDatabase _database = new HistoryDatabase();

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<SearchHistory> _historyList;

        public ObservableCollection<SearchHistory> HistoryList
        {
            get { return _historyList; }
            set
            {
                this._historyList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HistoryList"));
            }
        }

        public async Task FetchDataAsync(int userId)
        {
            var list = await _database.GetHistoryByUserAsync(userId);
            HistoryList = new ObservableCollection<SearchHistory>(list);
        }

        public async Task AddHistory(SearchHistory searchHistory) {
            await _database.AddHistoryAsync(searchHistory);
        }

        public async Task DeleteByUser(int userId)
        {
            await _database.DeleteByUser(userId);
        }

        public SearchHistoryViewModel(int userId) {
            FetchDataAsync(userId);
        }
        
    }
}
