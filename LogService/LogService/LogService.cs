using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace LogService
{
    public partial class LogService : ServiceBase
    {
        const string PATH = @"D:\log_full.txt";

        public LogService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("Log Service sendo iniciado", EventLogEntryType.Information);

            ThreadStart start = new ThreadStart(ProcessarLog);

            Thread tr = new Thread(start);

            tr.Start();
        }

        private void ProcessarLog()
        {
            while (true)
            {
                Thread.Sleep(5000);

                string txt = String.Empty;

                using (StreamReader stream = new StreamReader(PATH))
                {
                    txt = stream.ReadToEnd();
                }


                using (StreamWriter stream = new StreamWriter(PATH))
                {
                    txt += $"- Gerando novo log {DateTime.Now}";

                    stream.WriteLine(txt + Environment.NewLine);
                }
            }
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Log Service sendo parado", EventLogEntryType.Information);
        }
    }
}
