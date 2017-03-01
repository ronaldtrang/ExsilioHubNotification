using ExsilioHubNotification.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExsilioHubNotification.Client.NotificationAPI
{
    public class Notification
    {
        static HttpClient client = new HttpClient();

        public async Task<string> GetWithHttpMessageAsync(int id)
        {
            string template = null;
            client.BaseAddress = new Uri("http://localhost:26256/");
            var path = "/api/notification/get/" + id;
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                template = await response.Content.ReadAsAsync<string>();
            }

            return template;
        }

        public async Task<string> PostWithHttpMessageAsync(NotificationData data)
        {
            client.BaseAddress = new Uri("http://localhost:26256/");
            var path = "/api/notification/post";
            HttpResponseMessage response = await client.PostAsJsonAsync(path, data);
            string message = await response.Content.ReadAsAsync<string>();
            response.EnsureSuccessStatusCode();

            return message;
        }
    }
}
