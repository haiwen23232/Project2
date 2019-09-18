using System;
using System.Collections.Generic;
using shop.Model;

namespace shop.ViewModel
{
    public class SearchHistoryViewModel
    {

        public List<SearchHistory> histories { get; set; }

        public SearchHistoryViewModel()
        {
            histories = new List<SearchHistory>()
            {
                new SearchHistory(){History = "Adidas" },
                new SearchHistory(){History = "t-s" },
                new SearchHistory(){History = "sneaker" }
            };
        }
    }
}
