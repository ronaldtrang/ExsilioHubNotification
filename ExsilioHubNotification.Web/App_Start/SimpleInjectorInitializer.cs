[assembly: WebActivator.PostApplicationStartMethod(typeof(ExsilioHubNotification.Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace ExsilioHubNotification.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Repository;
    using Data;
    using SimpleInjector.Diagnostics;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            var registration = Lifestyle.Transient.CreateRegistration(typeof(ExsilioHubNotificationEntities), container);
            container.AddRegistration(typeof(ExsilioHubNotificationEntities), registration);
            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "do not show");

            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IEmailTemplateRepository, EmailTemplateRepository>();
        }
    }
}