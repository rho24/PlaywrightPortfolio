using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PlaywrightPortfolio.App_AutofacModules;

namespace PlaywrightPortfolio
{
    public class AutofacConfig
    {
        public static void Configure(MvcApplication mvcApplication) {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}