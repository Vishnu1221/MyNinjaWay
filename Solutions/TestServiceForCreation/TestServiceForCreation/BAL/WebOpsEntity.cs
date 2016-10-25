using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TestServiceForCreation.BAL
{
    [DataContract(Namespace="")]
    public class WebOpsEntity
    {
        [DataMember]
        public string invoice_Number { get; set; }
        [DataMember]
        public bool invertoryOrder { get; set; }
        [DataMember]
        public bool timeSentInGMT { get; set; }
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
    } 
}