using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace DALayer
{
    public static class ErrorLogger
    {
        public static void WriteLog(string message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"].ToString();

            StreamWriter writer = new StreamWriter(logPath, true);

            message = $"{DateTime.Now} : {message}";

            writer.WriteLine(message.Trim());

            writer.Dispose();
        }
    }
}