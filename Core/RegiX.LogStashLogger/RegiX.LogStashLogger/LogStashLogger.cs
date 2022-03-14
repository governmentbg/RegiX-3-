using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks.Dataflow;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.RecordLog;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TechnoLogica.RegiX.LogStashLogger
{
    [Export(typeof(ILogRecord))]
    public class LogStashLogger : ILogRecord
    {
        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Създава Log запис и го изпраща към logstash
        /// </summary>
        public void LogRecord(string operationFullName, RegiXLogRecordType logRecord, string error)
        {
            if (string.IsNullOrEmpty(error))
            {
                try
                {
                    UPLOAD_DATA.Post(new Tuple<string, RegiXLogRecordType>(operationFullName, logRecord));
                }
                catch (Exception ex)
                {
                    Logger.Error("Error while sending data to logstash:" + ex.Message);
                    Logger.Error("Logstash - not logged entry:" + Environment.NewLine + logRecord.XmlSerialize());
                }
            }
            else
            {
                Logger.Error("Received error from APIServiceCallsData:" + error);
            }
        }

        private static ActionBlock<Tuple<string, RegiXLogRecordType>> UPLOAD_DATA =
           new ActionBlock<Tuple<string, RegiXLogRecordType>>(
               async (data) =>
               {
                   bool error = false;
                   try
                   {
                       using (HttpClient client = new HttpClient())
                       {
                           string serializedLog = data.Item2.XmlSerialize();
                           string operationFullName = data.Item1;
                           var content = new StringContent(serializedLog, Encoding.UTF8, "application/xml");

                           var response = await client.PostAsync(ConfigurationManager.AppSettings["LoggingAddress"] + operationFullName, content);

                           if (!response.IsSuccessStatusCode)
                           {
                               Logger.Error("Logstash - status code:" + response.StatusCode);
                               error = true;
                           }
                       }
                   }
                   catch (Exception ex)
                   {
                       Logger.Error("Logstash - error: " + ex.Message);
                       error = true;
                   }
                   finally
                   {
                       if (error)
                       {
                           Logger.Error("Logstash - not logged entry:" + Environment.NewLine + data.Item2.XmlSerialize());
                       }
                   }
               }, new ExecutionDataflowBlockOptions
               {
                   MaxDegreeOfParallelism = 1
               }
           );
    }
}
