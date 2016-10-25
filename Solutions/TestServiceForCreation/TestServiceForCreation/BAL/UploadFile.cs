using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace TestServiceForCreation.BAL
{
    public static class UploadFile
    {
        public static void Upload(string ftpServer, string userName, string password, string filename)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.Credentials = new System.Net.NetworkCredential(userName, password);
                //client.UploadFile(ftpServer + "/" + new FileInfo(filename).Name, "STOR", filename);
                client.UploadFile(ftpServer +"/UPSInbox" + "/" + new FileInfo(filename).Name, filename);

            }
        }

    }
}