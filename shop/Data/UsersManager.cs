using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shop.Model;

namespace shop.Data
{
    public class UsersManager : Network
    {
        HttpClient client = new HttpClient();

        public bool FetchUserByEmailAsync(string email)
        {
            string url = URL + "users/GetByEmail/" + email;
            bool result = true;
            try
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    result = bool.Parse(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message + " Error from EMAIL");
            }
            return result;
        }

        public User GetUSerByEmail(string email)
        {
            string url = URL + "users/GetByEmailUser/" + email;
            User user = null;
            try
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message + " Error from Get user by EMAIL");
            }
            return user;
        }

        public User FetchUserByNameAsync(string name)
        {
            string url = URL + "users/GetByname/" + name;
            User user = null;

            try
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    if(content != null)
                        user = JsonConvert.DeserializeObject<User>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message + " Error from NAME");
            }
            return user;
        }

        public User FetcyUserByIdAsync(int id)
        {
            string url = URL + "users/" + id;
            User user = null;
            try
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    if (content != null)
                        user = JsonConvert.DeserializeObject<User>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message + " Error from ID");
            }
            return user;
        }

        public async Task CreateUser(User user)
        {
            string url = URL + "users";
            try
            {
                var response = await client.PostAsJsonAsync<User>(url,user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message + " Error from CREATE");
            }
        }

        public async Task UpdateUser(User user)
        {
            string url = URL + "users/" + user.UserId;
            try
            {
                var response = await client.PutAsJsonAsync<User>(url, user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message + " Error from UPDATE");
            }
        }

        public int GetFBUser(string token)
        {
            HttpClient httpClient = new HttpClient();
            var json = httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={token}").Result;
            FacebookUser facebookUser = JsonConvert.DeserializeObject<FacebookUser>(json);
            facebookUser.Email = facebookUser.Email.Replace(@"\u0040", "@");
            User fbUser = new User { Name = facebookUser.Name, Email = facebookUser.Email };
            User dbUser = GetUSerByEmail(fbUser.Email);
            if (GetUSerByEmail(fbUser.Email) == null)
            {
                CreateUser(fbUser).Wait();
                dbUser = GetUSerByEmail(fbUser.Email);
            }
            return dbUser.UserId;
        }
    }
}
