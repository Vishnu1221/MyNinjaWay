using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace TestServiceForCreation.UpsscModel
{
    [XmlRoot("Upsscs"), Serializable]
    public class Upsscs
    {
        [XmlAttribute("applicationVersion")]
        public string applicationVersion { get; set; }
        [XmlAttribute("schemaVersion")]
        public string schemaVersion { get; set; }
        [XmlElement("Header")]
        public Header header { get; set; }
        [XmlElement("OrderCreationRequest")]
        public OrderCreationRequest oderCreation { get; set; }  
    }
}