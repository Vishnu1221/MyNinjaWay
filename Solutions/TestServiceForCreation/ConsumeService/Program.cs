using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsumeService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.WebOpsEntity objWebops = new ServiceReference1.WebOpsEntity();
            objWebops.invertoryOrder = true;
            objWebops.invoice_Number = "1234RdsOrd897";
            objWebops.timeSentInGMT = true;
            objWebops.firstName = "WebOps";
            objWebops.lastName = "WebOps";
            ServiceReference1.OrderCreationClient processOrder = new ServiceReference1.OrderCreationClient();
            processOrder.ProcessRequest(objWebops);
       }
    }
}
