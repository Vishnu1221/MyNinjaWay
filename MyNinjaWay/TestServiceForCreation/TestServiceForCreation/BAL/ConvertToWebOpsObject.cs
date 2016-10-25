using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using TestServiceForCreation.BAL;
using System.IO;

namespace TestServiceForCreation
{
    public class ConvertToWebOpsObject
    {
        public WebOpsEntity ConvertObj(string XMLString, WebOpsEntity objWebOps)
        {
            XmlSerializer oXmlSerializer = new XmlSerializer(objWebOps.GetType());
            objWebOps = (WebOpsEntity)oXmlSerializer.Deserialize(new StringReader(XMLString));
            return objWebOps;
        }
    }
}