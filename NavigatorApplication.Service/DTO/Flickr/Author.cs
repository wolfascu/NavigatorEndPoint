namespace NavigatorApplication.Service.DTO.Flickr
{
    using System.Xml.Serialization;
    using NavigatorApplication.Service.DTO.Flickr.Constant;

    public class Author
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("uri")]
        public string Url { get; set; }

        [XmlElement(ElementName = "nsid", Namespace = XmlNamespaces.Flickr)]
        public string Id { get; set; }

        [XmlElement(ElementName = "buddyicon", Namespace = XmlNamespaces.Flickr)]
        public string IconUrl { get; set; }
    }
}
