namespace NavigatorApplication.Service.DTO.Flickr
{
    using NavigatorApplication.Service.DTO.Flickr.Constant;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "feed", Namespace = XmlNamespaces.Feed)]
    public class FlickrDeleteFeed : FlickrFeed
    {
        [XmlElement(ElementName = "deleted-entry", Namespace = XmlNamespaces.At)]
        public DeletedEntry DeletedEntry { get; set; }
    }
}
