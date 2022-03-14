using log4net;
using System;
using System.ComponentModel.Composition;
using System.Data.Common;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Common.Utils;
using TechnoLogica.RegiX.MFANotariesAdapter.Helpers;

namespace TechnoLogica.RegiX.MFANotariesAdapter.AdapterService
{
    [Export(typeof(IPersistanceProvider))]
    public class DBPersistanceProvider : IPersistanceProvider
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly NpgsqlDbUtils dbUtils;

        public DBPersistanceProvider()
        {
            this.dbUtils = CreateNpgsqlDbUtils();
        }

        public void PersistProcessing(decimal persistanceID, string verificationCode)
        {
            DbConnection connection = dbUtils.CreateDbConnection();
            try
            {
                connection.Open();
                dbUtils.InsertVerificationCode(connection, persistanceID, verificationCode);
            }
            finally
            {
                connection.Close();
            }
        }

        public void PersistResult(decimal persistanceID, ServiceResultData result)
        {
            //Вероятно не се извиква заради двойното подписване
        }

        public void Remove(decimal persistanceID, string verificationCode)
        {
            DbConnection connection = dbUtils.CreateDbConnection();
            try
            {
                connection.Open();
                dbUtils.RemovePersistance(connection, persistanceID, verificationCode);
            }
            finally
            {
                connection.Close();
            }
        }

        public ServiceResultData RetrieveResult(decimal persistanceID, string verificationCode)
        {
            //Да си извлече резултата -raw_signed_result
            DbConnection connection = dbUtils.CreateDbConnection();

            try
            {
                connection.Open();
                return dbUtils.GetSignedResult(connection, persistanceID, verificationCode);
            }
            finally
            {
                connection.Close();
            }
        }

        private NpgsqlDbUtils CreateNpgsqlDbUtils()
        {
            var result = new NpgsqlDbUtils(MFANotariesAdapter.ConnectionString.Value);
            return result;
        }
    }
}
