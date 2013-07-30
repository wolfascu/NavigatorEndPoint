using System.Xml.Serialization;

namespace NavigatorApplication.Service.DTO.Flickr
{
    /// <summary>
    /// Represents the Content field in flicker feed
    /// </summary>
    public class Content
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlText]
        public string Body { get; set; }
    }
}
