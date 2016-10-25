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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrderCreation
    {

        [OperationContract(IsOneWay=true)]
        [WebInvoke(Method="POST",BodyStyle=WebMessageBodyStyle.Bare,RequestFormat=WebMessageFormat.Xml,ResponseFormat=WebMessageFormat.Xml,UriTemplate="/Req")]
        void ProcessRequest(WebOpsEntity webopsObj);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/get/{orderID}")]
        WebOpsEntity getOrder(string orderID);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/getwrap/{orderID}")]
        WebOpsEntity getOrderWrapped(string orderID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "xml/{id}")]
        string xmlData(string id);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }
}
