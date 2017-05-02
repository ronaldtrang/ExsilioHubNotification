using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using ExsilioHubNotification.Web.Controllers;
using ExsilioHubNotification.Web.Models;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Moq;

namespace ExsilioHubNotification.Web.UnitTest
{
    [TestClass]
    public class NotificationControllerUnitTests
    {
        [TestMethod]
        public void Post()
        {
            // Email will be sent to C:\Temp
            NotificationData data = new NotificationData();
            data.From = "noreply@example.com";
            data.FromDisplayName = "Sender Test";
            data.To = "ronaldt@exsilio.com";
            data.Subject = "Test Test";
            data.Body = "Test Body1";

            NotificationController notification = new NotificationController();
            var result = notification.Post(data).GetAwaiter().GetResult();

            Assert.AreEqual("The email is successfully sent.", result);
        }
    }
}
