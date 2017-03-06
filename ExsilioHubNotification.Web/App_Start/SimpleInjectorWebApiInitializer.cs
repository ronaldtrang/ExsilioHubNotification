[assembly: WebActivator.PostApplicationStartMethod(typeof(ExsilioHubNotification.Web.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace ExsilioHubNotification.Web.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using Repository;
    using Data;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IEmailTemplateRepository, EmailTemplateRepository>();
            container.Register<ExsilioHubNotificationEntities>(Lifestyle.Scoped);
        }
    }
}