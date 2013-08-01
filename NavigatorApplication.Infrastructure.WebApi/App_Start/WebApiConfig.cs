namespace NavigatorApplication.Infrastructure.WebApi.App_Start
{
    using System.Web.Http;
   
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

            // Routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           
        }


    }
}