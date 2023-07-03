using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FluentFTP;
using System.Configuration;
using FluentFTP.Rules;

namespace FTP_Service
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        string localPath = ConfigurationManager.AppSettings["localPath"];
        string remotePath = ConfigurationManager.AppSettings["remotePath"];
        string ftpPath = ConfigurationManager.AppSettings["ftpPath"];
        string ftpUser = ConfigurationManager.AppSettings["ftpUser"];
        string ftpPass = ConfigurationManager.AppSettings["ftpPass"];
        int ftpPort = int.Parse(ConfigurationManager.AppSettings["ftpPort"]);
        string logPath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs"; // the path for servcice's logs
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            WriteToFile("Service is being started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = int.Parse(ConfigurationManager.AppSettings["repeatDelay"]);
            timer.Enabled = true;
            using (var ftp = new FtpClient(ftpPath, ftpUser, ftpPass, ftpPort))
            {
                ftp.Connect();
                ftp.CreateDirectory(remotePath, true);
            }
        }
        protected override void OnStop()
        {
            WriteToFile("Service is stopping at " + DateTime.Now);
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("Service is uploading at " + DateTime.Now);
            UploadToServer();
        }
        public void UploadToServer()
        {
            using (FtpClient ftp = new FtpClient(ftpPath, ftpUser, ftpPass))
            {
                ftp.Connect();
                ftp.UploadDirectory(localPath, remotePath, FtpFolderSyncMode.Update);
            }
        }
        public void WriteToFile(string Message)
        {
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            string logFile = logPath + @"\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(logFile))
            {
                using (StreamWriter sw = File.CreateText(logFile))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(logFile))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
