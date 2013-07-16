using System.ServiceModel.Syndication;

namespace NavigatorApplication.Infrastructure.WebApi
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using NavigatorApplication.Infrastructure.WebApi.App_Start;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            //GlobalConfiguration.Configuration.Formatters.Add(new SyndicationFeedFormatter());
            Bootstrapper.Initialise();
        }
    }
}