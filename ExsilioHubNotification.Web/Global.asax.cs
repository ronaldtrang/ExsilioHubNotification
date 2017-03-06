using System.Web.Http;
using System.Web.Routing;

namespace ExsilioHubNotification.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
