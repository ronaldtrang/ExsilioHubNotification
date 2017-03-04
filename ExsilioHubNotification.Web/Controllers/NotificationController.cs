using ExsilioHubNotification.Web.Models;
using System.ComponentModel;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;
using System;
using ExsilioHubNotification.Repository;
using NLog;
using NLog.Fluent;
using System.Security.Cryptography;
using ExsilioHubNotification.Data;

namespace ExsilioHubNotification.Web.Controllers
{
    public class NotificationController : ApiController
    {
        private IEmailTemplateRepository _repo;

        public NotificationController(IEmailTemplateRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get the email template based on the TemplatedId
        /// </summary>
        /// <param name="id">Provide the TemplateId</param>
        /// <returns></returns>
        [HttpGet]
        public string Get(int id)
        {
            EmailTemplateRepository repo = new EmailTemplateRepository(new ExsilioHubNotificationEntities());
            var result = repo.GetEmailTemplate(id);

            return result;
        }

        /// <summary>
        /// Send the email
        /// </summary>
        /// <param name="notification">Provide all of the require properties</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> Post(NotificationData notification)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            string message = String.Empty;

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
            mail.IsBodyHtml = true;

            // Callback when email is processed
            smtp.SendCompleted += (object sender, AsyncCompletedEventArgs e) =>
            {
                if (e.Error != null)
                {
                    message = "There was an error sending the email.";
                    NLog.Fluent.Log.Error().Message(message)
                               .Property("subject", mail.Subject)
                               .Exception(e.Error).Write();
                }
                else if (e.Cancelled)
                {
                    message = "The email has been cancelled.";

                    NLog.Fluent.Log.Error().Message(message)
                               .Property("subject", mail.Subject).Write();
                }
                else
                {
                    message = "The email is successfully sent.";

                    NLog.Fluent.Log.Info().Message(message)
                              .Property("subject", mail.Subject).Write();
                }

                mail.Dispose();
                smtp.Dispose();
            };

            await smtp.SendMailAsync(mail);

            return message;
        }
    }
}