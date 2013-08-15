namespace NavigatorApplication.Service.DTO.Flickr
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using NavigatorApplication.Service.DTO.Flickr.Constant;
    using NavigatorApplication.Service.DTO.Flickr.Interface;

    [XmlRoot(ElementName = "feed", Namespace = XmlNamespaces.Feed)]
    public class FlickrFeed : IFlickrFeed
    {
        [XmlElement(ElementName = "id")]
        public string FeedId { get; set; }

        [XmlIgnore]
        public string Id
        {
            get
            {
                FeedId = FeedId ?? "";
                string[] IdElements = FeedId.Split(':');
                return IdElements.Length > 2 ? IdElements[IdElements.Length - 1] : FeedId;
            }
            set
            {
                if (value.IndexOf(':') > 0)
                {
                    this.FeedId = value;
                }
                else
                {
                    this.FeedId = XmlNamespaces.Flickr + ":" + value;
                }
            }
        }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("updated")]
        public DateTime UpdatedDate { get; set; }

        [XmlElement("entry")]
        public List<FeedEntry> Entries { get; set; }

        public bool ShouldSerializeEntries()
        {
            return (this.Entries != null && this.Entries.Any());
        }

        [XmlElement(ElementName = "deleted-entry", Namespace = XmlNamespaces.At)]
        public DeletedEntry DeletedEntry { get; set; }

        public bool ShouldSerializeDeletedEntry()
        {
            return this.DeletedEntry != null;
        }
    }
}
