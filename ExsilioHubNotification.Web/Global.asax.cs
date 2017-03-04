using ExsilioHubNotification.Repository;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ExsilioHubNotification.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //var container = new SimpleInjector.Container();
            //container.Register<IEmailTemplateRepository, EmailTemplateRepository>();
            //container.Verify();
            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
