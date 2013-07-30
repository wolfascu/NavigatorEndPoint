using System.Xml.Serialization;

namespace NavigatorApplication.Service.DTO.Flickr
{
    /// <summary>
    /// Represntd update field in flicker feed
    /// </summary>
    public class FlickerUpdate
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}
