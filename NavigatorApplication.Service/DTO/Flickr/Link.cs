namespace NavigatorApplication.Service.DTO.Flickr
{
    using System.Xml.Serialization;

    public class Link
    {
        [XmlAttribute("rel")]
        public string Rel { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("href")]
        public string Href { get; set; }
    }
}
