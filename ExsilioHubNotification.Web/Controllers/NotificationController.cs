using ExsilioHubNotification.Web.Models;
using System.ComponentModel;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;
using NLog.Fluent;
using NLog.LayoutRenderers;
using System;

namespace ExsilioHubNotification.Web.Controllers
{
    public class NotificationController : ApiController
    {
        [HttpGet]
        public async Task Get()
        {
            NotificationData data = new NotificationData();
            data.From = "noreply@example.com";
            data.FromDisplayName = "Sender Test";
            data.To = "ronaldt@exsilio.com";
            data.Subject = "Test Test";
            data.Body = "Test Body";

            await Post(data);
        }

        [HttpPost]
        public async Task Post(NotificationData notification)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                if (string.IsNullOrEmpty(notification.FromDisplayName))
                {
                    mail.From = new MailAddress(notification.To);
                }
                else
                {
                    mail.From = new MailAddress(notification.From, notification.FromDisplayName);
                }

                mail.To.Add(new MailAddress(notification.To));
                mail.Subject = notification.Subject;
                mail.Body = notification.Body;
                
                // Callback when email is processed
                smtp.SendCompleted += (object sender, AsyncCompletedEventArgs e) => {
                    if (e.Error != null)
                    {
                        Log.Error().Message("There was an error sending the email.")
                                   .Property("subject", mail.Subject)
                                   .Exception(e.Error).Write();
                    }
                    else if (e.Cancelled)
                    {
                        Log.Error().Message("The email has been cancelled.")
                                   .Property("subject", mail.Subject).Write();
                    }
                    else
                    {
                        Log.Info().Message("The email is successfully sent.")
                                  .Property("subject", mail.Subject).Write();
                    }

                    mail.Dispose();
                    smtp.Dispose();
                };

                await smtp.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                Log.Error().Message("Error").Exception(ex).Write();
            }
        }
    }
}