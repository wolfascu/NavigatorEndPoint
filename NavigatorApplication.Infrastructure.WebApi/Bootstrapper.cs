using System.Web.Http;
using Microsoft.Practices.Unity;
using NavigatorApplication.Service.DTO;

namespace NavigatorApplication.Infrastructure.WebApi
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container
               .RegisterType<IUrlRepository, IUrlRepository>();
          
            return container;
        }
    }
}