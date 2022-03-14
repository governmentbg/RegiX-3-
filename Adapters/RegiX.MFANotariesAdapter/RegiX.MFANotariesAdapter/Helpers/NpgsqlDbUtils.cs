using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Data.Common;

namespace TechnoLogica.RegiX.MFANotariesAdapter.Helpers
{
    public class NpgsqlDbUtils : DbUtils
    {
        public NpgsqlDbUtils(string connectionString)
            : base(connectionString)
        {
        }

        public override DbConnection CreateDbConnection()
        {
            DbConnection dbConnection = new NpgsqlConnection(this.connectionString);
            return dbConnection;
        }

        public override DbCommand CreateCommand(string text = null, DbConnection dbConnection = null)
        {
            DbCommand command = new NpgsqlCommand();
            if (text != null)
            {
                command.CommandText = text;
            }

            if (dbConnection != null)
            {
                command.Connection = dbConnection;
            }

            return command;
        }

        public override DbDataAdapter CreateDataAdapter(DbCommand command)
        {
            DbDataAdapter dataAdapter = new NpgsqlDataAdapter();
            dataAdapter.SelectCommand = command;
            return dataAdapter;
        }

        public override DbParameter CreateParameter(string parameterName, NpgsqlDbType parameterType, object value = null, ParameterDirection direction = ParameterDirection.Input)
        {
            var parameter = new NpgsqlParameter(parameterName, parameterType)
            {
                Direction = direction
            };

            if (value != null)
            {
                parameter.Value = value;
            }

            return parameter;
        }
    }
}
