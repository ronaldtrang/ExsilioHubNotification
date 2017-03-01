using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExsilioHubNotification.Data
{
    public partial class ExsilioHubNotificationEntities : DbContext
    {
        public ExsilioHubNotificationEntities(string connectionString) : base(connectionString) 
        {
        }
    }
}
