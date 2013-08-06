namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Fomatters
{
    using System;
    using System.Net.Http.Formatting;
    using NavigatorApplication.Service.DTO.Flickr.Interface;

    /// <summary>
    /// Media Formatter responsible to format the Flciker Feed Media
    /// </summary>
    public class FlickerFeedMediaFormatter : XmlMediaTypeFormatter
    {
        public FlickerFeedMediaFormatter() : base()
        {
            //TODO: Using Flickr Namespace  Remove
            this.UseXmlSerializer = true;
        }

        public override bool CanReadType(Type type)
        {
            /* Will Handle the model only which are inheritted from Feed Interface.
             * It will avoid problems while this Formatter will be integrated to other projects
             * */
            return typeof(IFlickrFeed).IsAssignableFrom(type);
        }

        public override bool CanWriteType(Type type)
        {
            /* Will Handle the object formatting for objects which are inheritted from Feed Interface.
             * It will avoid problems while this Formatter will be integrated to other projects
             * */
            return typeof(IFlickrFeed).IsAssignableFrom(type);
        }
    }
}
