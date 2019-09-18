using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shop.Model;

namespace shop.Data
{
    public class CategoriesManager : Network
    {
        HttpClient client = new HttpClient();
        List<Category> Categories = null;

        public async Task<List<Category>> FetchCategoriesAsync()
        {
            string url = URL + "categories/";
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Categories = JsonConvert.DeserializeObject<List<Category>>(content);

                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message);
            }
            return Categories;
        }
    }
}
