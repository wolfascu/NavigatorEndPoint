using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NavigatorApplication.Service.DTO.Flickr.Constant;
using NavigatorApplication.Service.DTO.Flickr.Interface;

namespace NavigatorApplication.Service.DTO.Flickr
{
    /// <summary>
    /// Represents Root response which is sent by Flicker to API
    /// </summary>
    [XmlRoot(ElementName = "feed", Namespace = XmlNamespaces.Feed)]
    public class FlickerFeed : IFlickerFeed
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("updated")]
        public DateTime UpdatedDate { get; set; }

        [XmlElement("entry")]
        public List<FeedEntry> Entries { get; set; }

    }
}
