using ExsilioHubNotification.Data;
using System.Linq;

namespace ExsilioHubNotification.Repository
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
        private ExsilioHubNotificationEntities _db;

        public EmailTemplateRepository(ExsilioHubNotificationEntities db)
        {
            _db = db;
        }

        public string GetEmailTemplate(int templateId)
        {
            var emailTemplate = (from t in _db.EmailTemplates
                                 where t.EmailTemplateId == templateId
                                 select t.Template).FirstOrDefault();

            return emailTemplate;
        }
    }
}
