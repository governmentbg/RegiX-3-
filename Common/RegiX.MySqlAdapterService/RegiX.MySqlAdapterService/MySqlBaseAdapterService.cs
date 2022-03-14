using MySql.Data.MySqlClient;
using System;
using System.Linq;
using TechnoLogica.RegiX.Adapters.Common;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.MySqlAdapterService
{
    public class MySqlBaseAdapterService : BaseAdapterService
    {
        //[Export(typeof(ParameterInfo))]
        //public ParameterInfo<string> ConnectionString { get; set; }

        public override string CheckRegisterConnection()
        {
            try
            {
                var connectionString = this.GetParameters().ParameterList.Where(p => p.Key == "ConnectionString").FirstOrDefault();
                if (connectionString != null && !String.IsNullOrEmpty(connectionString.CurrentValue))
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString.CurrentValue))
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
