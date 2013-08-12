namespace NavigatorApplication.Infrastructure.WebApi.Extensions.Fomatters
{
    using System;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;

    using NavigatorApplication.Service.DTO.Flickr.Interface;

    public class FlickerFeedMediaFormatter : XmlMediaTypeFormatter
    {
        private const string AtomMediaType = "application/atom+xml";
        
        public FlickerFeedMediaFormatter()
        {
            //TODO: Using Flickr Namespace  Remove
            this.UseXmlSerializer = true;

            //TODO: Determine Content Type Header
           //SupportedMediaTypes.Add(new MediaTypeHeaderValue(AtomMediaType));
        }

        public override bool CanReadType(Type type)
        {
            return typeof(IFlickrFeed).IsAssignableFrom(type);
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(IFlickrFeed).IsAssignableFrom(type);
        }
    }
}
