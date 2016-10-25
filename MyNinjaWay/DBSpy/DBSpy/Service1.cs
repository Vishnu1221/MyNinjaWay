using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.IO;
using System.Threading;
using DBSpy.Model;
using System.ServiceModel;
using System.Net;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace DBSpy
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private System.Timers.Timer aTimer;
        protected override void OnStart(string[] args)
        {
            this.writetofile("Simple Service started {0}");

            // aTimer = new System.Timers.Timer(60 * 60 * 1000); //one hour in milliseconds
            aTimer = new System.Timers.Timer(300000); //one hour in milliseconds
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            this.ScheduleService();
        }


        private System.Threading.Timer scheduler;
        private void ScheduleService()
        {
            try
            {
                aTimer.Stop();
                this.writetofile(string.Format("Service Exceuted at {0}", DateTime.Now));
                CallService(fetchData());
                aTimer.Start();
            }
            catch (Exception ex)
            {
                writetofile("Simple Service Error on: {0} " + ex.Message + ex.StackTrace);

                //Stop the Windows Service.
                using (System.ServiceProcess.ServiceController serviceController = new System.ServiceProcess.ServiceController("SimpleService"))
                {
                    serviceController.Stop();
                }
            }
        }

        private void CallService(List<WebOpsServiceRef.WebOpsEntity> list)
        {
            try
            {
                foreach (var item in list)
                {
                    XmlSerializer ser = new XmlSerializer(item.GetType());
                    MemoryStream mem = new MemoryStream();
                    ser.Serialize(mem, item);
                    string data =
                    Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                    WebClient webClient = new WebClient();
                    webClient.Headers["Content-type"] = "application/xml";
                    webClient.Encoding = Encoding.UTF8;
                    webClient.UploadString("http://192.168.50.240:74/OrderCreation.svc/req", "POST", data);
                }

            }
            catch (Exception ex)
            {
                writetofile("Simple Service Error on: {0} " + ex.Message + ex.StackTrace);
            }
        }

        public List<WebOpsServiceRef.WebOpsEntity> fetchData()
        {
            List<WebOpsServiceRef.WebOpsEntity> OrderList = new List<WebOpsServiceRef.WebOpsEntity>();
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
                        OrderList.Add(new WebOpsServiceRef.WebOpsEntity
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

        private void SchedularCallback(object e)
        {
            this.writetofile("Simple Service Log: {0}");
            this.ScheduleService();
        }

        private void writetofile(string p)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\ServiceLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(string.Format(p, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                writer.Close();
            }
        }

        protected override void OnStop()
        {
            this.writetofile("Simple service stopped {0}");
            this.scheduler.Dispose();
        }
    }
}
