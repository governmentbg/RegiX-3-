using System;
using System.Data.SqlClient;
using System.Linq;
using TechnoLogica.RegiX.Common;
using TechnoLogica.RegiX.Adapters.Common;

namespace TechnoLogica.RegiX.SQLServerAdapterService
{
    public class SQLServerAdapterService : BaseAdapterService
    {
        //[Export(typeof(ParameterInfo))]
        //public static ParameterInfo<string> ConnectionString { get; set; }

        public override string CheckRegisterConnection()
        {
            try
            {
                var connectionString = this.GetParameters().ParameterList.Where(p => p.Key == "ConnectionString").FirstOrDefault();
                if (connectionString != null && !String.IsNullOrEmpty(connectionString.CurrentValue))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString.CurrentValue))
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
