using ExsilioHubNotification.Data;
using System;

namespace ExsilioHubNotification.Repository
{
    public class RepositoryBase : IDisposable
    {
        bool disposed = false;

        public ExsilioHubNotificationEntities NotificationContext;

        public RepositoryBase()
        {
            NotificationContext = new ExsilioHubNotificationEntities();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                this.NotificationContext.Dispose();
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
