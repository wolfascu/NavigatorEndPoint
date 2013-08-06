using NavigatorApplication.Infrastructure.WebApi.Extensions.Handler;

namespace NavigatorApplication.Infrastructure.WebApi.App_Start
{
    using System.Web.Http;
    using System.Web.Http.Tracing;
    using NavigatorApplication.Infrastructure.WebApi.Extensions.Tracing;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Handlers
           /* config.MessageHandlers.Add(new WLWMessageHandler());
            config.MessageHandlers.Add(new EnrichingHandler());*/

            // Formatters
           //config.Formatters.Remove(config.Formatters.XmlFormatter);
           // config.Formatters.XmlFormatter.UseXmlSerializer = true;
            
           
            //config.Formatters.Add(new AtomPubCategoryMediaTypeFormatter());

            // Filters
            //config.Filters.Add(new ValidateModelStateAttribute());

            //Handler
            config.MessageHandlers.Add(new LogHandler());

            //Trace 
            config.Services.Replace(typeof(ITraceWriter), new SimpleTracer());

            // Routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           
        }


    }
}