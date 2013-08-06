using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NavigatorApplication.Service.DTO.Flickr
{
    public class DeletedEntry
    {
        [XmlAttribute("ref")]
        public string Ref { get; set; }

        [XmlAttribute("when")]
        public DateTime When { get; set; }

        [XmlElement("link")]
        public List<Link> Links { get; set; }
    }
}
