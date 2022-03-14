using System;
using TechnoLogica.RegiX.Common;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using TechnoLogica.RegiX.Adapters.Common;

namespace TechnoLogica.RegiX.OracleAdapterService
{
    public class OracleBaseAdapterService : BaseAdapterService
    {
        //[Export(typeof(ParameterInfo))]
        //public static ParameterInfo<string> ConnectionString { get; set; }

        public override string CheckRegisterConnection()
        {
            try
            {
                var connectionString = this.GetParameters().ParameterList.Where(p => p.Key == Constants.ConnectionStringParameterKeyName).FirstOrDefault();
                if (connectionString != null && !String.IsNullOrEmpty(connectionString.CurrentValue))
                {
                    using (OracleConnection connection = new OracleConnection(connectionString.CurrentValue))
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
