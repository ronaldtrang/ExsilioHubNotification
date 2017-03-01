using ExsilioHubNotification.Client.Models;
using ExsilioHubNotification.Client.NotificationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExsilioHubNotification.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Notification notification = new Notification();
            SendEmail().GetAwaiter().GetResult();
        }

        private async static Task SendEmail()
        {
            NotificationData data = new NotificationData
            {
                From = "noreply@example.com",
                FromDisplayName = "Sender Test",
                To = "ronaldt@exsilio.com",
                Subject = "Client Subject",
                Body = "Send from client"
            };

            Notification notification = new Notification();
            var result = await notification.PostWithHttpMessageAsync(data);
        }
    }
}
