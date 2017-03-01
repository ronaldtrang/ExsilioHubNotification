using ExsilioHubNotification.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ExsilioHubNotification.Repository.UnitTest
{
    [TestClass]
    public class EmailTemplateRepositoryUnitTests
    {
        public EmailTemplateRepositoryUnitTests()
        {
            // Mock EmailTemplate
            var template = new EmailTemplate
            {
                EmailTemplateId = 1,
                Name = "Test Template",
                Template = "<h1>Test Template</h1>",
                Subject = "Test Subject"
            };

            // Mock EmailTemplateRepository
            Mock<IEmailTemplateRepository> mockRepo = new Mock<IEmailTemplateRepository>();
            mockRepo.Setup(r => r.GetEmailTemplate(It.IsAny<int>())).Returns(template.Template);

            // Complete the setup of the Mock EmailTemplateRepository
            this.MockEmailTemplateRepository = mockRepo.Object;
        }

        [TestMethod]
        public void GetEmailTemplate()
        {
            int templateId = 1;
            var result = this.MockEmailTemplateRepository.GetEmailTemplate(templateId);

            Assert.AreEqual("<h1>Test Template</h1>", result);
        }

        public IEmailTemplateRepository MockEmailTemplateRepository;
    }
}
