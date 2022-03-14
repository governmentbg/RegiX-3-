using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace TechnoLogica.RegiX.DataAccess.DataClasses
{
    public static class AdministrationServiceAPISData
    {
        public static bool CheckAccessForOperation(
            RegiXContext context,
            decimal certificateID,
            string operationName,
            string contractName,
            out decimal operationID)
        {
            using (context)
            {
                operationID =    
                    context.Database.SqlQuery<decimal>(
                        "SELECT API_SERVICE_OPERATION_ID " +                       
                        "FROM API_SERVICE_OPERATIONS "+
                        "JOIN API_SERVICES ON API_SERVICES.API_SERVICE_ID = API_SERVICE_OPERATIONS.API_SERVICE_ID "+
                        "WHERE API_SERVICE_OPERATIONS.NAME= @p_operation_name " +
                        "AND API_SERVICES.Contract = @p_contract_name", 
                        new object[]
                        {
                            new SqlParameter("@p_operation_name",  operationName),
                            new SqlParameter("@p_contract_name",  contractName)
                        }
                    ).First();

                SqlParameter resultParam = new SqlParameter("@p_result", SqlDbType.Decimal);
                resultParam.Direction = System.Data.ParameterDirection.Output;
                SqlParameter operationIDParam = new SqlParameter("@p_api_service_operation_id", operationID);
                SqlParameter certificateIDParam = new SqlParameter("@p_consumer_certificate_id", certificateID);
                context.Database.ExecuteSqlCommand("EXEC @p_result = has_consumer_operation_access @p_api_service_operation_id = @p_api_service_operation_id, @p_consumer_certificate_id = @p_consumer_certificate_id",
                    new object[] 
                    { 
                        resultParam,
                        operationIDParam,
                        certificateIDParam,
                    }
                );
                return Convert.ToBoolean((Decimal)resultParam.Value);
            }
        }

        public static CONSUMER_CERTIFICATES GetAdministrationCertificate(RegiXContext context, string thumbprint)
        {
            CONSUMER_CERTIFICATES result = null;
            using (context)
            {
                result = (from ad in context.API_SERVICE_CONSUMERS
                          join cert in context.CONSUMER_CERTIFICATES on ad.API_SERVICE_CONSUMER_ID equals cert.API_SERVICE_CONSUMER_ID
                          where cert.THUMBPRINT.ToLower() == thumbprint.ToLower()
                          select cert).FirstOrDefault();
            }

            return result;
        }

        public static List<API_SERVICES> GetAllServiceAPIs(RegiXContext context)
        {
            List<API_SERVICES> result = null;
            using (context)
            {
                result = context.API_SERVICES.ToList();
            }
            return result;
        }

        public static API_SERVICES GetServiceAPIByName(RegiXContext context, string apiName)
        {
            API_SERVICES result = null;

            using (context)
            {
                result = (from srv in context.API_SERVICES
                          where srv.NAME.ToLower() == apiName.ToLower()
                          select srv).FirstOrDefault();
            }

            return result;
        }

        public static API_SERVICES GetServiceAPIByContract(RegiXContext context, string contract)
        {
            API_SERVICES result = null;

            using (context)
            {
                result = (from srv in context.API_SERVICES
                          where srv.CONTRACT.ToLower() == contract.ToLower()
                          select srv).FirstOrDefault();
            }

            return result;
        }

        public static void GetAssemblyByContract(RegiXContext context, string contract, out string assembly)
        {
            using (context)
            {
                assembly = (from srv in context.API_SERVICES
                          where srv.CONTRACT.ToLower() == contract.ToLower()
                          select srv.ASSEMBLY).FirstOrDefault();
            }
        }

        public static bool CheckAPIServiceIsEnabled(RegiXContext context, string contract)
        {
            using (context)
            {
                bool result =
                    context.Database.SqlQuery<bool>(
                        "SELECT ENABLED FROM API_SERVICES WHERE CONTRACT = @p_contract",
                        new object[]{
                            new SqlParameter("@p_contract", contract)
                        }
                    ).First();
                return result;
            }
        }

        public static List<string> GetAllServiceNames(RegiXContext context)
        {
            using (context)
            {
                return (from srv in context.API_SERVICES
                        select srv.NAME.ToLower())
                        .ToList();
            }
        }
    }
}
