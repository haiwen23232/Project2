using System;
using System.Collections.Generic;
using SQLite;

namespace shop.Model
{
    public class SearchHistory
    {
        [PrimaryKey, AutoIncrement]
        public int SearchId { get; set; }
        public string HistoryStr { get; set; }
        public int UserId { get; set; }

        public SearchHistory()
        {
        }

        public SearchHistory(string historyStr, int userId) {
            this.HistoryStr = historyStr;
            this.UserId = userId;
        }
    }
}
