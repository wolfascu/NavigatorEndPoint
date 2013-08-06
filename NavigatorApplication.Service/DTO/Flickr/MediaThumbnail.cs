namespace NavigatorApplication.Service.DTO.Flickr
{
    using System.Xml.Serialization;

    public class MediaThumbnail
    {
        [XmlAttribute("url")]
        public string Url { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

        [XmlAttribute("width")]
        public int Width { get; set; }
    }
}
