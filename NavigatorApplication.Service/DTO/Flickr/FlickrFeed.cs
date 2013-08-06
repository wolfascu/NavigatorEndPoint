using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NavigatorApplication.Service.DTO.Flickr.Constant;
using NavigatorApplication.Service.DTO.Flickr.Interface;

namespace NavigatorApplication.Service.DTO.Flickr
{
    [XmlRoot(ElementName = "feed", Namespace = XmlNamespaces.Feed)]
    public class FlickrFeed : IFlickrFeed
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("updated")]
        public DateTime UpdatedDate { get; set; }

        [XmlElement("entry")]
        public List<FeedEntry> Entries { get; set; }

    }
}
