using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Net;

namespace TestWebOpsPost
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ServiceReference1.WebOpsEntity> lst = fetchData();

            foreach (var item in lst)
            {
             
            XmlSerializer ser = new XmlSerializer(item.GetType());
                MemoryStream mem = new MemoryStream();
                ser.Serialize(mem, item);
                string data =
                Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/xml";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString("http://localhost:50137/OrderCreation.svc/req", "POST", data); 
            } 
        }

        public static List<ServiceReference1.WebOpsEntity> fetchData()
        {
            List<ServiceReference1.WebOpsEntity> OrderList = new List<ServiceReference1.WebOpsEntity>();
            try
            {
                using (WebOpsQCEntities objWebOpsQCEntities = new WebOpsQCEntities())
                {
                    var item = (from objuser in objWebOpsQCEntities.TBL_USER
                                join
                                    objSR in objWebOpsQCEntities.TBL_SALES_REP on objuser.ID equals objSR.USER_ID
                                join objcase in objWebOpsQCEntities.TBL_CASE on objSR.ID equals objcase.SALES_REP_ID
                                where objcase.INVOICE_NUMBER != string.Empty
                                select new
                                {
                                    objcase.INVOICE_NUMBER,
                                    objuser.FIRST_NAME,
                                    objuser.LAST_NAME,
                                    objcase.ORDER_NUMBER
                                }
                        ).Take(10).ToList();


                    item.ToList().ForEach(rec =>
                    {
                        OrderList.Add(new ServiceReference1.WebOpsEntity
                        {
                            invoice_Number = rec.INVOICE_NUMBER,
                            firstName = rec.FIRST_NAME,
                            lastName = rec.LAST_NAME,
                            invertoryOrder = true,
                            timeSentInGMT = true
                        });
                    });

                }
            }
            catch (Exception ex)
            {

            }
            return OrderList;
        }
    }
}
