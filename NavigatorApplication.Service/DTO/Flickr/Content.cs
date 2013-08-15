using System.Xml.Serialization;

namespace NavigatorApplication.Service.DTO.Flickr
{
    public class Content
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlText]
        public string Body { get; set; }
    }
}
