using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TechnoLogica.RegiX.DataAccess.DataClasses
{
    public static class RegisterAdaptersData
    {
        public class PropertyAccessResult
        {
            public string PATH_TO_ROOT { get; set; }
            public bool HAS_ACCESS { get; set; }
        }

        public static String GetAdapterContractName(RegiXContext context, string contractAPI, string contractOperation)
        {
            using (context)
            {
                var res = from sao in context.API_SERVICE_ADAPTER_OPERATIONS
                          join so in context.API_SERVICE_OPERATIONS on sao.API_SERVICE_OPERATION_ID equals so.API_SERVICE_OPERATION_ID
                          join s in context.API_SERVICES on so.API_SERVICE_ID equals s.API_SERVICE_ID
                          join ao in context.ADAPTER_OPERATIONS on sao.ADAPTER_OPERATION_ID equals ao.ADAPTER_OPERATION_ID
                          join ra in context.REGISTER_ADAPTERS on ao.REGISTER_ADAPTER_ID equals ra.REGISTER_ADAPTER_ID
                         where s.CONTRACT == contractAPI && so.NAME == contractOperation
                        select ra.CONTRACT;
                return res.FirstOrDefault();
            }
        }

        public static void GetAdapterContractName(RegiXContext context, decimal apiServiceCall, out string adapterContract, out string apiServiceContract, out string apiServiceOperation)
        {
            using (context)
            {
                var res = (from sc in context.API_SERVICE_CALLS
                          join so in context.API_SERVICE_OPERATIONS on sc.API_SERVICE_OPERATION_ID equals so.API_SERVICE_OPERATION_ID
                          join s in context.API_SERVICES on so.API_SERVICE_ID equals s.API_SERVICE_ID
                          join sao in context.API_SERVICE_ADAPTER_OPERATIONS on so.API_SERVICE_OPERATION_ID equals sao.API_SERVICE_OPERATION_ID
                          join ao in context.ADAPTER_OPERATIONS on sao.ADAPTER_OPERATION_ID equals ao.ADAPTER_OPERATION_ID
                          join ra in context.REGISTER_ADAPTERS on ao.REGISTER_ADAPTER_ID equals ra.REGISTER_ADAPTER_ID
                          where sc.API_SERVICE_CALL_ID == apiServiceCall
                          select new { AdapterContract = ra.CONTRACT, APIServiceContract = s.CONTRACT, APIServiceOperation = so.NAME } 
                          ).FirstOrDefault();
                adapterContract = res?.AdapterContract;
                apiServiceContract = res?.APIServiceContract;
                apiServiceOperation = res?.APIServiceOperation;
            }
        }

        public static void getAPIServiceContract(RegiXContext context, decimal apiServiceCall, out string apiServiceContract, out string assemblyName)
        {
            using (context)
            {
                var res = from sc in context.API_SERVICE_CALLS
                          join so in context.API_SERVICE_OPERATIONS on sc.API_SERVICE_OPERATION_ID equals so.API_SERVICE_OPERATION_ID
                          join a in context.API_SERVICES on so.API_SERVICE_ID equals a.API_SERVICE_ID
                          where sc.API_SERVICE_CALL_ID == apiServiceCall
                          select new {Contract = a.CONTRACT, Assembly = a.ASSEMBLY};
                var contractAndAssembly = res.FirstOrDefault();
                apiServiceContract = contractAndAssembly?.Contract;
                assemblyName = contractAndAssembly?.Assembly;
            }
        }


        public static Dictionary<string, bool> GetPropertyAccess(RegiXContext context, decimal certificateID, decimal registerAdapterID, string operationName)
        {
            using (context)
            {
                Dictionary<string, bool> result = new Dictionary<string, bool>();
                var varResult =
                    from cea in context.CERTIFICATE_ELEMENT_ACCESS
                    join roe in context.REGISTER_OBJECT_ELEMENTS on cea.REGISTER_OBJECT_ELEMENT_ID equals roe.REGISTER_OBJECT_ELEMENT_ID
                    join ao in context.ADAPTER_OPERATIONS on roe.REGISTER_OBJECT_ID equals ao.REGISTER_OBJECT_ID
                    where cea.CONSUMER_CERTIFICATE_ID == certificateID &&
                          ao.REGISTER_ADAPTER_ID == registerAdapterID &&
                          ao.NAME == operationName
                    select new PropertyAccessResult() { HAS_ACCESS = cea.HAS_ACCESS, PATH_TO_ROOT = roe.PATH_TO_ROOT };    
                
                if (varResult.Count() == 0)
                {
                    varResult =
                        from cea in context.CONSUMER_ROLE_ELEMENT_ACCESS
                        join cc in context.CERTIFICATE_CONSUMER_ROLE on cea.CONSUMER_ROLE_ID equals cc.CONSUMER_ROLE_ID
                        join roe in context.REGISTER_OBJECT_ELEMENTS on cea.REGISTER_OBJECT_ELEMENT_ID equals roe.REGISTER_OBJECT_ELEMENT_ID
                        join ao in context.ADAPTER_OPERATIONS on roe.REGISTER_OBJECT_ID equals ao.REGISTER_OBJECT_ID
                        where cc.CONSUMER_CERTIFICATE_ID == certificateID &&
                              ao.REGISTER_ADAPTER_ID == registerAdapterID &&
                              ao.NAME == operationName
                        select new PropertyAccessResult() { HAS_ACCESS = cea.HAS_ACCESS, PATH_TO_ROOT = roe.PATH_TO_ROOT };
                }

                foreach (var res in varResult)
                {
                    result.Add(res.PATH_TO_ROOT, res.HAS_ACCESS);
                }
                return result;
            }
        }

        public static decimal GetRegisterAdapterID(RegiXContext context, string contractName)
        {
            using (context)
            {
                return context.REGISTER_ADAPTERS.Where(ra => ra.CONTRACT == contractName).Select(ra => ra.REGISTER_ADAPTER_ID).Single();
            }
        }

        public static void DeleteAdapter(RegiXContext context, decimal adapterId)
        {
            using (context)
            {
                SqlParameter adapterIdParam = new SqlParameter("@p_adapter_id",  adapterId);

                context.Database.ExecuteSqlCommand("execute delete_adapter(@p_adapter_id)",
                    new object[]
                    {
                        adapterIdParam
                    });
            }
        }
    }
}
