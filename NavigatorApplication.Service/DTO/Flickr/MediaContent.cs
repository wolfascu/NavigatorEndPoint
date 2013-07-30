using System.Xml.Serialization;

namespace NavigatorApplication.Service.DTO.Flickr
{
    /// <summary>
    /// Represents Content in media namespace in flicker feed 
    /// </summary>
    public class MediaContent
    {
        [XmlAttribute("url")]
        public string Url { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

        [XmlAttribute("width")]
        public int Width { get; set; }
    }
}
