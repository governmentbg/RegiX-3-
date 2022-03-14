using System;
using System.Collections.Generic;
using System.Linq;

namespace TechnoLogica.RegiX.DataAccess.DataClasses
{
    public static class ServiceAdaptersData
    {
        public static REGISTER_ADAPTERS GetServiceAdapter(RegiXContext context, string contractName)
        {
            REGISTER_ADAPTERS serviceAdapter = null;
            using (context)
            {
                serviceAdapter =
                    context
                        .REGISTER_ADAPTERS
                        .Where(sa => sa.CONTRACT == contractName)
                        .FirstOrDefault();
            }
            return serviceAdapter;
        }

        public static List<REGISTER_ADAPTERS> GetServiceAdapters(RegiXContext context)
        {
            List<REGISTER_ADAPTERS> serviceAdapters = null;
            using (context)
            {
                serviceAdapters =
                    context
                        .REGISTER_ADAPTERS
                        .ToList();
            }
            return serviceAdapters;
        }

        public static ADAPTER_PING_RESULTS AddPing(RegiXContext context, decimal registerAdapterID, DateTime executionTime, long? pingTime)
        {

            var pingResult = context.ADAPTER_PING_RESULTS.Create();
            pingResult.REGISTER_ADAPTER_ID = registerAdapterID;
            pingResult.REPLY_TIME = pingTime;
            pingResult.TIMEOUT = (short)((pingTime.HasValue) ? 0 : 1);
            pingResult.EXECUTE_TIME = executionTime;
            context.ADAPTER_PING_RESULTS.Add(pingResult);
            context.SaveChanges();
            return pingResult;
        }

        public static List<ADAPTER_HEALTH_FUNCTIONS> GetHealthFunctions(RegiXContext context, decimal registerAdapterID)
        {
            using (context)
            {
                var result =
                     context
                     .ADAPTER_HEALTH_FUNCTIONS
                     .Include("REGISTER_ADAPTERS")
                     .Where(ahf => ahf.REGISTER_ADAPTER_ID == registerAdapterID)
                     .ToList();
                return result;
            }
        }

        public static void AddHealthFunction(RegiXContext context, decimal registerAdapterID, string code, string description)
        {
            using (context)
            {
                ADAPTER_HEALTH_FUNCTIONS adapterHealthFunction = context.ADAPTER_HEALTH_FUNCTIONS.Create();
                adapterHealthFunction.REGISTER_ADAPTER_ID = registerAdapterID;
                adapterHealthFunction.CODE = code;
                adapterHealthFunction.DESCRIPTION = description;
                context.ADAPTER_HEALTH_FUNCTIONS.Add(adapterHealthFunction);
                context.SaveChanges();
            }
        }

        public static ADAPTER_HEALTH_RESULTS AddHealthResult(RegiXContext context, ADAPTER_HEALTH_FUNCTIONS adapterHealthFunction, DateTime executeTime, string result, string error)
        {
            using (context)
            {
                ADAPTER_HEALTH_RESULTS adapterHealthResult = context.ADAPTER_HEALTH_RESULTS.Create();
                adapterHealthResult.REGISTER_ADAPTER_ID = adapterHealthFunction.REGISTER_ADAPTER_ID;
                adapterHealthResult.ADAPTER_HEALTH_FUNCTION_ID = adapterHealthFunction.ADAPTER_HEALTH_FUNCTION_ID;
                adapterHealthResult.HEALTH_ERROR = error;
                adapterHealthResult.HEALTH_RESULT = result;
                adapterHealthResult.EXECUTE_TIME = executeTime;
                context.ADAPTER_HEALTH_RESULTS.Add(adapterHealthResult);
                context.SaveChanges();
                return adapterHealthResult;
            }
        }
    }
}
