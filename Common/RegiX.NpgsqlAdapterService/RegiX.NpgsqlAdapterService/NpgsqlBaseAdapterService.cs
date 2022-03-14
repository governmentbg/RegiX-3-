using Npgsql;
using System;
using System.Linq;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.NpgsqlAdapterService
{
    public class NpgsqlBaseAdapterService : BaseAdapterService
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
                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString.CurrentValue))
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
