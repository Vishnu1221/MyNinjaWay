using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Configuration;

namespace TestServiceForCreation.BAL
{
    public static class ValidateUPSXML
    {
        /// <summary>
        /// Validate XML Against XSD
        /// </summary>
        /// <param name="XMLString">Converted XML String Need for SPLUS</param>
        public static void  ValidateXML(string XMLString,string orderid)
        {
            bool valid = true;
            //Creat XML Document 
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XMLString);
            //Setting Schema(XSD)
            XmlSchemaSet xlSchema = new XmlSchemaSet();
            xlSchema.Add("", AppDomain.CurrentDomain.BaseDirectory + @"XSD\OrderCreation.xsd");
            //Adding Schema to XML Doument Schema attribute 
            doc.Schemas.Add(xlSchema);
            //Validate with Schema
            doc.Validate((s, e) =>
            {
                valid = false;
            });

            //IF pass
            if (valid)
            {
                string fileName = "OrderCreation_" + orderid +"_" + DateTime.Now.ToString("dd-MM-yyyy")+ ".xml";
                //Save to Folder
                doc.Save(AppDomain.CurrentDomain.BaseDirectory + @"\XMLFile\"+fileName);
                string UserName = ConfigurationManager.AppSettings["UName"];
                string Paswd = ConfigurationManager.AppSettings["Password"];
                UploadFile.Upload("ftp://192.168.50.99:21", UserName, Paswd, AppDomain.CurrentDomain.BaseDirectory + @"\XMLFile\"+fileName);
            }
           else
            {
               
           }
        } 

    }
}