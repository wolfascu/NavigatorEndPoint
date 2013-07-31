using System.Xml.Serialization;

namespace NavigatorApplication.Service.DTO.Flickr
{
    public class FlickrUpdate
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}
