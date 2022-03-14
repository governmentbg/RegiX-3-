using System;
using System.ComponentModel.Composition;
using System.ServiceModel;
using System.ServiceModel.Channels;
using TechnoLogica.RegiX.Core.Helpers.Interfaces;

namespace TechnoLogica.RegiX.Core.Helpers
{
    /// <summary>
    /// Помощен клас за извличане на информация за клиентското IP
    /// </summary>
    [Export(typeof(IIPHelper))]
    public class IPHelper : IIPHelper
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static readonly log4net.ILog Logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Зарежда клиентското IP. То е записано в X-Forwarded-For header-а от SSL Offloader-а.
        /// </summary>
        public string GetClientIP()
        {
            try
            {
                HttpRequestMessageProperty requestProperty = (HttpRequestMessageProperty)OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name];
                string xForwardedFor = requestProperty.Headers["X-Forwarded-For"];

                OperationContext context = OperationContext.Current;
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                string ip = endpoint.Address + ":" + endpoint.Port;

                if (string.IsNullOrEmpty(xForwardedFor))
                {
                    return ip;
                }
                else
                {
                    string result = string.Format("X-Forwarded-For={0};proxy ip={1}", xForwardedFor, ip);
                    return result;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return string.Empty;
            }
        }
    }
}
