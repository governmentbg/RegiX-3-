//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace TechnoLogica.RegiX.DataAccess.DataClasses
{
    public static class OperationData
    {
        public static void GenerateDefaultAccessRulesForOperations(RegiXContext context,
                                                              decimal certificateId,
                                                              decimal adapterId,
                                                              bool defaultAccess,
                                                              bool overwriteOperations)
        {
            using (context)
            {
                SqlParameter certificateIdParam = new SqlParameter("@p_consumer_certificate_id",  certificateId);
                SqlParameter adapterIdParam = new SqlParameter("@p_register_adapter_id",  adapterId);
                SqlParameter defaultAccessParam = new SqlParameter("@p_has_access",defaultAccess);
                SqlParameter overwriteOperationsParam = new SqlParameter("@p_overwrite",  overwriteOperations);

                context.Database.ExecuteSqlCommand("execute gen_certificate_oper_access @p_consumer_certificate_id, @p_register_adapter_id, @p_has_access, @p_overwrite",
                    new object[] 
                    { 
                        certificateIdParam,
                        adapterIdParam,
                        defaultAccessParam,
                        overwriteOperationsParam,
                    }
                );
            }
        }
    }
}
