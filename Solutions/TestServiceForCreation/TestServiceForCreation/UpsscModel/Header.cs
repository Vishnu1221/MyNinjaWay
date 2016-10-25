using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace TestServiceForCreation.UpsscModel
{
    [XmlRoot("Header")]
    public class Header
    {
        [XmlElement("messageIdentifier")]
        public string messageIdentifier { get; set; }
        [XmlElement("processIdentifier")]
        public string processIdentifier { get; set; }
        [XmlElement("messageProducer")]
        public string messageProducer { get; set; }
        [XmlElement("messageConsumer")]
        public string messageConsumer { get; set; }
        [XmlElement("messageFunction")]
        public string messageFunction { get; set; }
        [XmlElement("messageDateTime")]
        public DateTime messageDateTime { get; set; }
    }
}