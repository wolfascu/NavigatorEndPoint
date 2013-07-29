namespace NavigatorApplication.Infrastructure.WebApi.App_Start
{
    using AutoMapper;
    using NavigatorApplication.Infrastructure.WebApi.Extensions.Registry;
    
    using NavigatorApplication.Infrastructure.WebApi.Extensions.Fomatters;
    using System.Web.Http;
   
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Handlers
           /* config.MessageHandlers.Add(new WLWMessageHandler());
            config.MessageHandlers.Add(new EnrichingHandler());*/

            // Formatters
           config.Formatters.Remove(config.Formatters.XmlFormatter);
           // config.Formatters.XmlFormatter.UseXmlSerializer = true;
            
            config.Formatters.Add(new AtomPubMediaFormatter());
            //config.Formatters.Add(new AtomPubCategoryMediaTypeFormatter());

            // Filters
            //config.Filters.Add(new ValidateModelStateAttribute());

            // Routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            Mapper.Reset();
            Mapper.Initialize(x =>
            {
                x.AddProfile<FeedProfile>();
              
            });

            Mapper.AssertConfigurationIsValid();
        }


    }
}