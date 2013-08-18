using System;
using System.IO;

namespace NavigatorApplication.Infrastructure.WebApi
{
    using NavigatorApplication.Infrastructure.WebApi.App_Start;
    using NavigatorApplication.Service.Registry;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Optimization;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //string l4net = Server.MapPath("~/log4net.config");
            //log4net.Config.XmlConfigurator.Configure(new FileInfo(l4net));

            //string logFile = Server.MapPath("~/Logs/log.sqlite");
            //LogConfig.Configure(logFile, Server.MapPath("~/Logs"));

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FormatterConfig.RegisterFormatters(GlobalConfiguration.Configuration.Formatters);

            AutomapperRegistry.Configure();

            Bootstrapper.Initialise();
        }
    }
}