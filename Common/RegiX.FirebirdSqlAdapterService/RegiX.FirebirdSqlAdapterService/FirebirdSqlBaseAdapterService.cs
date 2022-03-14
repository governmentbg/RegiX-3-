using System;
using System.Linq;
using TechnoLogica.RegiX.Common;
using FirebirdSql.Data.FirebirdClient;
using TechnoLogica.RegiX.Adapters.Common;

namespace TechnoLogica.RegiX.FirebirdSqlAdapterService
{
    public class FirebirdSqlBaseAdapterService : BaseAdapterService
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
                    using (FbConnection connection = new FbConnection(connectionString.CurrentValue))
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
