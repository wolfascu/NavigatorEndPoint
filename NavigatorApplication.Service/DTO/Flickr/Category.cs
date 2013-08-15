namespace NavigatorApplication.Service.DTO.Flickr
{
    using System.Xml.Serialization;

    public class Category
    {
        [XmlAttribute("term")]
        public string Term { get; set; }

        [XmlAttribute("scheme")]
        public string Scheme { get; set; }
    }
}
