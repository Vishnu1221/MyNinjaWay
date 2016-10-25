using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace TestServiceForCreation.UpsscModel
{
    public class OrderCreationRequest
    {
        [XmlElement("OrderProcessingInstructions")]
        public OrderProcessingInstructions orderProcessing { get; set; }
        [XmlElement("Authorizer")]
        public Authorizer authorize { get; set; }

    }
}