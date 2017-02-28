using System;

namespace ExsilioHubNotification.Repository
{
    public interface IEmailTemplateRepository : IDisposable
    {
        string GetEmailTemplate(int templateId);
    }
}
