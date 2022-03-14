using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Core.Interfaces;
using TechnoLogica.RegiX.Core.Interfaces.TransportObjects;

namespace TechnoLogica.RegiX.CoreServices
{
    public class RegiXReceiveResult : IReceiveResult
    {
        public void ReceiveResult(ServiceResultData argument, string callbackURL)
        {
            //TODO: Add error handling
            IRegiXEntryPointV2 callbackService = new ChannelFactory<IRegiXEntryPointV2>(new BasicHttpBinding("CallbackBinding"), callbackURL).CreateChannel();
            callbackService.ExecuteCallback(new ResultWrapper() { Result = argument });
            //TODO: Add API Service Call record
        }
    }
}
