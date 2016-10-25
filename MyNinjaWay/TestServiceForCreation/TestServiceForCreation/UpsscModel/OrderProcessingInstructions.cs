using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TestServiceForCreation.UpsscModel
{
    public class OrderProcessingInstructions
    {
        [XmlElement("inventoryOrder")]
        public bool inventoryOrder { get; set; }
        [XmlElement("customerOrderNumber")]
        public string customerOrderNumber { get; set; }
        [XmlElement("timeSentInGMT")]
        public bool timeSentInGMT { get; set; }
    }
}
