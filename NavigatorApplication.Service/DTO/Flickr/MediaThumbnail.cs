using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlickerAPI.Common.FlickerModels
{
    /// <summary>
    /// Represents thumbnail field in media namespace in flicker feed
    /// </summary>
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
