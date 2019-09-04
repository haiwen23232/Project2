using System;
using System.Collections.Generic;

namespace shop.Model
{
    public class Category
    {
        public string CategoryName { set; get; }

        public Category()
        {
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){CategoryName = "Hoddie" },
                new Category(){CategoryName = "T-shirt" },
                new Category(){CategoryName = "Pants" },
                new Category(){CategoryName = "Sneaker" }

            };
            return categories;
        }
    }
}


