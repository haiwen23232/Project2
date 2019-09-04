using System;
using System.Collections.Generic;

namespace shop.Model
{
    public class SearchHistory
    {
        public string History { get; set; }

        public SearchHistory()
        {
        }

        public List<SearchHistory> GetHistories()
        {
            List<SearchHistory> searchHistories = new List<SearchHistory>()
            {
                new SearchHistory(){History = "History samples" },
                new SearchHistory(){History = "Hoodies" },
                new SearchHistory(){History = "Seakers" },
                new SearchHistory(){History = "Pants" }
            };
            return searchHistories;
        }
    }
}
