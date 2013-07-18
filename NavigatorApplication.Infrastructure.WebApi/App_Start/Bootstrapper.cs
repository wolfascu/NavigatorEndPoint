namespace NavigatorApplication.Infrastructure.WebApi.App_Start
{
    using System.Web.Http;
    using Microsoft.Practices.Unity;
    using NavigatorApplication.Service.Repository;

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

            container.RegisterType<IFeedRepository, FeedRepository>();
          
            return container;
        }
    }
}