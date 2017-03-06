using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using ExsilioHubNotification.Repository;
using ExsilioHubNotification.Data;
using ExsilioHubNotification.Web.Controllers;
using ExsilioHubNotification.Web.Models;
using Moq;

namespace ExsilioHubNotification.Web.UnitTest
{
    [TestClass]
    public class NotificationControllerUnitTests
    {
        IEmailTemplateRepository MockEmailTemplateRepository;

        [TestMethod]
        public void GetEmailTemplate()
        {
            // Mock EmailTemplate
            var template = new EmailTemplate
            {
                EmailTemplateId = 1,
                Name = "Test Template",
                Template = "<h1>Test Template</h1>",
                Subject = "Test Subject"
            };

            // Mock IEmailTemplateRepository
            Mock<IEmailTemplateRepository> mockRepo = new Mock<IEmailTemplateRepository>();
            mockRepo.Setup(r => r.GetEmailTemplate(It.IsAny<int>())).Returns(template.Template);

            // Complete the setup of the Mock EmailTemplateRepository
            MockEmailTemplateRepository = mockRepo.Object;

            NotificationController notification = new NotificationController(MockEmailTemplateRepository);
            var result = notification.Get(1);

            Assert.AreEqual("<h1>Test Template</h1>", result);
        }

        [TestMethod]
        public async Task Post()
        {
            NotificationData data = new NotificationData();
            data.From = "noreply@example.com";
            data.FromDisplayName = "Sender Test";
            data.To = "ronaldt@exsilio.com";
            data.Subject = "Test Test";
            data.Body = "Test Body";

            NotificationController notification = new NotificationController(MockEmailTemplateRepository);
            await notification.Post(data);
        }
    }
}
