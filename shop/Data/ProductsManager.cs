using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shop.Model;

namespace shop.Data
{
    public class ProductsManager : Network
    {
        HttpClient client = new HttpClient();
        List<Product> Products = null;

        public async Task<List<Product>> FetchProductsByCategoryAsync(int catId)
        {
            string url = URL + "products/category/" + catId;
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Products = JsonConvert.DeserializeObject<List<Product>>(content);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message);
            }
            return Products;

        }

        public async Task<List<Product>> FetchProductsByKeywordAsync(string keyword)
        {
            string url = URL + "products/search/" + keyword.ToLower();
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Products = JsonConvert.DeserializeObject<List<Product>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message);
            }
            return Products;

        }

    }
}

