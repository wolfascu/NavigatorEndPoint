using System;
using System.Net.Http.Formatting;
using NavigatorApplication.Service.DTO.Flickr.Interface;

namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Fomatters
{
    /// <summary>
    /// Media Formatter responsible to format the Flciker Feed Media
    /// </summary>
    public class FlickerFeedMediaFormatter : XmlMediaTypeFormatter
    {
        
        public FlickerFeedMediaFormatter()
            : base()
        {
            // By default It will use xmlSerializer
            this.UseXmlSerializer = true;
        }

        public override bool CanReadType(Type type)
        {
            /* Will Handle the model only which are inheritted from Feed Interface.
             * It will avoid problems while this Formatter will be integrated to other projects
             * */
            return typeof(IFlickerFeed).IsAssignableFrom(type);
        }

        public override bool CanWriteType(Type type)
        {
            /* Will Handle the object formatting for objects which are inheritted from Feed Interface.
             * It will avoid problems while this Formatter will be integrated to other projects
             * */
            return typeof(IFlickerFeed).IsAssignableFrom(type);
        }
    }
}
