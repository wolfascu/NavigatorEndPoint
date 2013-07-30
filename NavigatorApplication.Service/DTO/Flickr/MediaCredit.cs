using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlickerAPI.Common.FlickerModels
{
    /// <summary>
    /// Represents Credit field in Media namespace in Flicker Feed
    /// </summary>
    public class MediaCredit
    {
        [XmlAttribute("role")]
        public string Role { get; set; }

        [XmlText]
        public string Info { get; set; }
    }
}
