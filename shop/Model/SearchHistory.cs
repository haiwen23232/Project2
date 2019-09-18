using System;
using System.Collections.Generic;

namespace shop.Model
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string History { get; set; }

        public SearchHistory()
        {
        }
    }
}
