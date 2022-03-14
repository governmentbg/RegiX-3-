using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.LegacyCore.Helpers
{
    public static class IServiceRequestDataExtension
    {
        public static void InitializeFrom(this Common.TransportObjects.IServiceRequestData parameter, Common.TransportObjects.ServiceRequestData request)
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

        public static void InitializeFrom(this Common.TransportObjects.IServiceRequestData parameter, TransportObject.Signed.ServiceRequestData request)
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

        public static void InitializeFrom(this Common.TransportObjects.IServiceRequestData parameter, TransportObject.ServiceRequestData request)
        {
            parameter.SetArgument(request.Argument);
            parameter.CallbackURL = request.CallbackURL;
            //TODO: Fix the call context
            //parameter.CallContext = request.CallContext;
            parameter.CitizenEGN = request.CitizenEGN;
            parameter.EIDToken = request.EIDToken;
            parameter.EmployeeEGN = request.EmployeeEGN;
            parameter.ReturnAccessMatrix = false;
            parameter.SignResult = true;
        }
    }
}
