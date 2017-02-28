using System.Linq;

namespace ExsilioHubNotification.Repository
{
    public class EmailTemplateRepository : RepositoryBase, IEmailTemplateRepository
    {
        public string GetEmailTemplate(int templateId)
        {
            var emailTemplate = (from t in NotificationContext.EmailTemplates
                                 where t.EmailTemplateId == templateId
                                 select t.Template).FirstOrDefault();

            return emailTemplate;
        }
    }
}
