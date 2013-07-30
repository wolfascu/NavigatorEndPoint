using System.Xml.Serialization;

namespace NavigatorApplication.Service.DTO.Flickr
{
    /// <summary>
    /// Represents Media Link 
    /// </summary>
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
