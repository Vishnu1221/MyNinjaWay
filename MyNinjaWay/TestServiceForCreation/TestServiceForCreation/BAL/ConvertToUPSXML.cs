using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestServiceForCreation.UpsscModel;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text;

namespace TestServiceForCreation.BAL
{
    public static class ConvertToUPSXML
    {
        public static void ConvertToXML(Upsscs ups)
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            //setting.Encoding = new UnicodeEncoding(false, false);
            setting.Encoding = Encoding.UTF8;
            setting.OmitXmlDeclaration = false;
            //Represents an XML document,           
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            // Initializes a new instance of the XmlDocument class. 
            XmlSerializer xmlSerializer = new XmlSerializer(ups.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, ups);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                //Call Validate Method 
                ValidateUPSXML.ValidateXML(xmlDoc.InnerXml,ups.oderCreation.orderProcessing.customerOrderNumber);
            }
        }
    }
}