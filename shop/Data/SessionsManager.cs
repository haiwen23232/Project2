using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shop.Model;

namespace shop.Data
{
    public class SessionsManager : Network
    {
        HttpClient client = new HttpClient();
        List<Session> ConferenceSessions = null;

        public async Task<List<Session>> FetchSessionsAsync()
        {
            string url = URL +"sessions/";
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ConferenceSessions = JsonConvert.DeserializeObject<List<Session>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"       Error{0} ", ex.Message);
            }
            return ConferenceSessions;
        }

    }
}
