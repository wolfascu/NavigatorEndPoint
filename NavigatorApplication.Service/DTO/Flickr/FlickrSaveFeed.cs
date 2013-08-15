namespace NavigatorApplication.Service.DTO.Flickr
{
    using NavigatorApplication.Service.DTO.Flickr.Constant;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "feed", Namespace = XmlNamespaces.Feed)]
    public class FlickrSaveFeed : FlickrFeed
    {
        [XmlElement("entry")]
        public List<FeedEntry> Entries { get; set; }
    }
}
