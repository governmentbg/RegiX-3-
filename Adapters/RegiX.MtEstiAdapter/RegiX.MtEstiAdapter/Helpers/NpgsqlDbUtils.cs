using Npgsql;
using NpgsqlTypes;
using System;
using System.Data;
using System.Data.Common;

namespace TechnoLogica.RegiX.MtEstiAdapter.Helpers
{
    public class NpgsqlDbUtils : DbUtils
    {
        public NpgsqlDbUtils(string connectionString, bool shouldGenerateEmail, string estiUrl, string emailSubject, string emailBody)
            : base(connectionString, shouldGenerateEmail, estiUrl, emailSubject, emailBody, shouldInsertLidoRequest: true)
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

        public override DbParameter CreateParameter(string parameterName, CustomDbType parameterType, object value = null, ParameterDirection direction = ParameterDirection.Input)
        {
            NpgsqlDbType type = ParseDbType(parameterType);
            var parameter = new NpgsqlParameter(parameterName, parameterType: type)
            {
                Direction = direction
            };

            if (value != null)
            {
                parameter.Value = value;
            }

            return parameter;
        }

        private NpgsqlDbType ParseDbType(CustomDbType parameterType)
        {
            switch (parameterType)
            {
                case CustomDbType.Varchar: return NpgsqlDbType.Varchar;
                case CustomDbType.Timestamp: return NpgsqlDbType.Timestamp;
                case CustomDbType.Text: return NpgsqlDbType.Text;
                case CustomDbType.Bigint: return NpgsqlDbType.Bigint;
                case CustomDbType.Date: return NpgsqlDbType.Date;
                case CustomDbType.Boolean: return NpgsqlDbType.Boolean;
                case CustomDbType.Integer: return NpgsqlDbType.Integer;
                case CustomDbType.Numeric: return NpgsqlDbType.Numeric;
                default: throw new ArgumentException("Invalid option: " + parameterType.ToString());
            }
        }
    }
}
