using ExsilioHubNotification.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExsilioHubNotification.Repository
{
    public class DisposableService : IDisposable
    {
        bool disposed = false;

        ExsilioHubNotificationEntities entities = new ExsilioHubNotificationEntities();

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                this.entities.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            disposed = true;
        }
    }
}
