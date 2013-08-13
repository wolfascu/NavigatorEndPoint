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

        [XmlAttribute(AttributeName = "ref")]
        public string EntryRef { get; set; }

        [XmlIgnore]
        public string Ref
        {
            get
            {
                EntryRef = EntryRef ?? "";
                string[] refElements = EntryRef.Split(':');
                return refElements.Length > 2 ? refElements[refElements.Length - 1] : EntryRef;
            }
            set
            {
                this.EntryRef = value;
            }
        }


        [XmlAttribute("when")]
        public DateTime When { get; set; }

        [XmlElement("link")]
        public List<Link> Links { get; set; }
    }
}
