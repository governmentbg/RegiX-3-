using TechnoLogica.RegiX.LegacyCore.TransportObject;

namespace TechnoLogica.RegiX.LegacyCore.Helpers
{
    public static class ServiceCheckResultArgumentExtension
    {
        public static Common.TransportObjects.ServiceCheckResultArgument ToV2(this ServiceCheckResultArgument serviceCheckResultArgument)
        {
            return new Common.TransportObjects.ServiceCheckResultArgument() { ServiceCallID = serviceCheckResultArgument.ServiceCallID };
        }
    }
}
