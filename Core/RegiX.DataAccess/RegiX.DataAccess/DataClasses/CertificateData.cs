//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TechnoLogica.RegiX.DataAccess.DataClasses
{
    public static class CertificateData
    {
        public static void DeleteCertificate(RegiXContext context, decimal certificate_id)
        {
            using (context)
            {
                SqlParameter certificateIdParam = new SqlParameter("@p_certificate_id", certificate_id);
                //using (var command = new SqlCommand("delete_certificate") { CommandType = System.Data.CommandType.StoredProcedure })
                context.Database.ExecuteSqlCommand("exec delete_certificate @p_certificate_id",
                    new object[]
                    {
                        certificateIdParam
                    });
            }
        }

        public static string GetOrganizationByCertificateID(RegiXContext context, decimal certificateID)
        {
            using (context)
            {
                SqlParameter certificateIdParam = new SqlParameter("@p_consumer_certificate_id",  certificateID);                

                return 
                    context.Database.SqlQuery<string>(
                        "SELECT api_service_consumers.NAME " +                    
                        "FROM api_service_consumers " +
                        "JOIN consumer_certificates ON consumer_certificates.api_service_consumer_id = api_service_consumers.api_service_consumer_id " +
                        "WHERE consumer_certificates.consumer_certificate_id = @p_consumer_certificate_id",
                        new object[]{                        
                            certificateIdParam
                        }).First();
            }
        }
    }
}
