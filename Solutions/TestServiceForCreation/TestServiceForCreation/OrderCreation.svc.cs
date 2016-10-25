using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TestServiceForCreation.BAL;

namespace TestServiceForCreation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class OrderCreation : IOrderCreation
    {
        public void ProcessRequest(WebOpsEntity webopsObj)
        {
            MapToSPLUS.MapWebopsToSPLUS(webopsObj);
        }

        public WebOpsEntity getOrder(string orderID)
        {
            WebOpsEntity objWebOpsEntity = new WebOpsEntity();
            objWebOpsEntity.firstName = "TestfName";
            objWebOpsEntity.lastName = "TestLastName";
            objWebOpsEntity.invertoryOrder = true;
            objWebOpsEntity.invoice_Number = "XX896JYT";
            objWebOpsEntity.timeSentInGMT = false;

            return objWebOpsEntity;
        }

        public WebOpsEntity getOrderWrapped(string orderID)
        {
            WebOpsEntity objWebOpsEntity = new WebOpsEntity();
            objWebOpsEntity.firstName = "TestfName";
            objWebOpsEntity.lastName = "TestLastName";
            objWebOpsEntity.invertoryOrder = true;
            objWebOpsEntity.invoice_Number = "XX896JYT";
            objWebOpsEntity.timeSentInGMT = false;

            return objWebOpsEntity;
        }

        public string xmlData(string id)
        {
            return "You requested product (xml Response)" + id;
        }
    }
}
