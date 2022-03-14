using System.Data.SqlClient;

namespace TechnoLogica.RegiX.DataAccess.DataClasses
{
    public static class AccessMatrixData
    {
        public static void GenerateDefaulAccessRulesForObject(RegiXContext context,
                                                              decimal certificateId,
                                                              decimal objectId,
                                                              bool defaultAccess,
                                                              bool overwriteObjectElements)
        {
            using (context)
            {
                SqlParameter certificateIdParam = new SqlParameter("@p_consumer_certificate_id", certificateId);
                SqlParameter objectIdParam = new SqlParameter("@p_register_object_id", objectId);               
                SqlParameter defaultAccessParam = new SqlParameter("@p_has_access", defaultAccess);              
                SqlParameter overwriteObjectElementsParam = new SqlParameter("@p_overwrite", overwriteObjectElements);
                context.Database.ExecuteSqlCommand("EXECUTE gen_certificate_element_access @p_consumer_certificate_id, @p_register_object_id, @p_has_access, @p_overwrite",
                    new object[] 
                    { 
                        certificateIdParam,
                        objectIdParam,
                        defaultAccessParam,
                        overwriteObjectElementsParam,
                    }
                );
            }
        }
    }
}
