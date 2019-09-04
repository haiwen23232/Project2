using System;
using System.Collections.Generic;
using shop.Model;

namespace shop.ViewModel
{
    public class CategoryViewModel
    {
        public List<Category> categories;

        public CategoryViewModel()
        {
            this.categories = new Category().GetCategories();
        }
    }
}
