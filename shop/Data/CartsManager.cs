using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shop.Model;

namespace shop.Data
{
    public class CartsManager : Network
    {
        HttpClient client = new HttpClient();
        List<Cart> Carts = null;

        public async Task<List<Cart>> FetchCartsByUserAsync(int userId)
        {
            string url = URL + "carts/GetByUser/" + userId;
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Carts = JsonConvert.DeserializeObject<List<Cart>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message);
            }
            return Carts;
        }

        public async Task CreateCart(Cart cart)
        {
            string url = URL + "carts";
            try
            {
                var response = await client.PostAsJsonAsync<Cart>(url, cart);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message + " Error from CREATE");
            }
        }
    }
}
