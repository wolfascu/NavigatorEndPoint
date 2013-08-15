namespace NavigatorApplication.Service.DTO.Flickr
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using NavigatorApplication.Service.DTO.Flickr.Constant;

    public class FeedEntry
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "id")]
        public string EntryId { get; set; }

        [XmlIgnore]
        public string Id
        {
            get
            {
                EntryId = EntryId ?? "";
                string[] IdElements = EntryId.Split(':');
                return IdElements.Length > 2 ? IdElements[IdElements.Length - 1] : EntryId;
            }
            set
            {
                this.EntryId = value;
            }
        }

        [XmlElement("published")]
        public DateTime PublishedDate { get; set; }

        [XmlElement("updated")]
        public DateTime UpdatedDate { get; set; }

        [XmlElement("content")]
        public Content Content { get; set; }

        [XmlElement("author")]
        public Author Author { get; set; }

        [XmlElement("category")]
        public List<Category> Categories { get; set; }

        [XmlElement(ElementName = "woeid", Namespace = XmlNamespaces.Woe)]
        public string WoeId { get; set; }

        [XmlElement(ElementName = "lat", Namespace = XmlNamespaces.Geo)]
        public double Latitude { get; set; }

        [XmlElement(ElementName = "long", Namespace = XmlNamespaces.Geo)]
        public double Longitude { get; set; }

        [XmlElement(ElementName = "point", Namespace = XmlNamespaces.GeoRss)]
        public string Point { get; set; }

        [XmlElement(ElementName = "date_taken", Namespace = XmlNamespaces.Flickr)]
        public DateTime DateTaken { get; set; }

        [XmlElement(ElementName = "safety", Namespace = XmlNamespaces.Flickr)]
        public string Safety { get; set; }

        [XmlElement(ElementName = "update", Namespace = XmlNamespaces.Flickr)]
        public List<FlickrUpdate> Updates { get; set; }


        [XmlElement(ElementName = "title", Namespace = XmlNamespaces.Media)]
        public string MediaTitle { get; set; }

        [XmlElement(ElementName = "credit", Namespace = XmlNamespaces.Media)]
        public MediaCredit MediaCredit { get; set; }

        [XmlElement(ElementName = "content", Namespace = XmlNamespaces.Media)]
        public MediaContent MediaContent { get; set; }

        [XmlElement(ElementName = "thumbnail", Namespace = XmlNamespaces.Media)]
        public List<MediaThumbnail> MediaThumbnails { get; set; }

        [XmlElement("link")]
        public List<Link> Links { get; set; }

    }
}
