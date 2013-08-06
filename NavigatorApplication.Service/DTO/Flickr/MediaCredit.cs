namespace NavigatorApplication.Service.DTO.Flickr
{
    using System.Xml.Serialization;

    public class MediaCredit
    {
        [XmlAttribute("role")]
        public string Role { get; set; }

        [XmlText]
        public string Info { get; set; }
    }
}
