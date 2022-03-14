using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoLogica.RegiX.Common.DataContracts;
using TechnoLogica.RegiX.Common.TransportObjects;

namespace TechnoLogica.RegiX.Core.Utils
{
    public static class IServiceRequestDataExtension
    {
        public static void InitializeFrom(this IServiceRequestData parameter, ServiceRequestData request)
        {
            parameter.SetArgument(request.Argument);
            parameter.CallbackURL = request.CallbackURL;
            parameter.CallContext = request.CallContext;
            parameter.CitizenEGN = request.CitizenEGN;
            parameter.EIDToken = request.EIDToken;
            parameter.EmployeeEGN = request.EmployeeEGN;
            parameter.ReturnAccessMatrix = request.ReturnAccessMatrix;
            parameter.SignResult = request.SignResult;
        }
    }
}
