using IBM.Data.Informix;
using System;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common;

namespace TechnoLogica.RegiX.InformixAdapterService
{
    public class InformixBaseAdapterService : BaseAdapterService
    {
        public override string CheckRegisterConnection()
        {
            try
            {
                var connectionString = this.GetParameters().ParameterList.Where(p => p.Key == "ConnectionString").FirstOrDefault();
                if (connectionString != null && !String.IsNullOrEmpty(connectionString.CurrentValue))
                {
                    using (IfxConnection connection = new IfxConnection(connectionString.CurrentValue))
                    {
                        connection.Open();
                        return Constants.ConnectionOk;
                    };
                }
                else
                {
                    return Constants.ConnectionStringNotSet;
                }
            }
            catch (Exception ex)
            {
                return String.Format(Constants.ConnectionException, ex.Message);
            }
        }
    }
}
