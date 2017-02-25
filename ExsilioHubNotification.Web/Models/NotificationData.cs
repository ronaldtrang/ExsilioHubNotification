using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExsilioHubNotification.Web.Models
{
    public class NotificationData
    {
        public string From { get; set; }
        public string FromDisplayName { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}