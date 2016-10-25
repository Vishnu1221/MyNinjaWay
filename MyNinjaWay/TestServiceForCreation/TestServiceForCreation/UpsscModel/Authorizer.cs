using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TestServiceForCreation.UpsscModel
{
    public class Authorizer
    {
        [XmlElement("firstName")]
        public string firstName { get; set; }
        [XmlElement("lastName")]
        public string lastName { get; set; }

    }
}
