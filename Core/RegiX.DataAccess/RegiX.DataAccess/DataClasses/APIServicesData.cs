//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TechnoLogica.RegiX.DataAccess.DataClasses
{
    public static class APIServicesData
    {
        public static void DeleteAPIService(RegiXContext context, decimal apiServiceId)
        {
            using (context)
            {
                SqlParameter apiServiceIdParam = new SqlParameter("@p_api_service_id", apiServiceId);

                context.Database.ExecuteSqlCommand("execute delete_api_service(@p_api_service_id)",
                    new object[]
                    {
                        apiServiceIdParam
                    });
            }
        }
    }
}
