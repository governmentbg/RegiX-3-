namespace TechnoLogica.RegiX.LegacyCore.Helpers
{
    public static class ServiceRequestDataExtensions
    {
        public static Common.TransportObjects.ServiceRequestData ToServiceRequestData(this TransportObject.Signed.ServiceRequestData request)
        {
            return new Common.TransportObjects.ServiceRequestData()
            {
                Argument = request.Argument,
                CallbackURL = request.CallbackURL,
                CallContext = request.CallContext,
                CitizenEGN = request.CitizenEGN,
                EIDToken = request.EIDToken,
                EmployeeEGN = request.EmployeeEGN,
                Operation = request.Operation,
                ReturnAccessMatrix = request.ReturnAccessMatrix,
                SignResult = request.SignResult
            };
        }

        public static Common.TransportObjects.ServiceRequestData ToServiceRequestData(this TransportObject.ServiceRequestData request)
        {
            return new Common.TransportObjects.ServiceRequestData()
            {
                Argument = request.Argument,
                CallbackURL = request.CallbackURL,
                CallContext = 
                    new Common.DataContracts.CallContext()
                    {
                        Remark = request.CallContext
                    },
                CitizenEGN = request.CitizenEGN,
                EIDToken = request.EIDToken,
                EmployeeEGN = request.EmployeeEGN,
                Operation = request.Operation,
                ReturnAccessMatrix = false,
                SignResult = false
            };
        }
    }
}
