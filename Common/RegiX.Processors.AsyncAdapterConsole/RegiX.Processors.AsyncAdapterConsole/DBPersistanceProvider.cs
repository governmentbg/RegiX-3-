using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using TechnoLogica.RegiX.Adapters.Common.Interfaces;
using TechnoLogica.RegiX.Common.TransportObjects;
using TechnoLogica.RegiX.Processors.AsyncAdapterConsole.DB;
using System.Linq;
using TechnoLogica.RegiX.Common.Utils;
using log4net;

namespace TechnoLogica.RegiX.Processors.AsyncAdapterConsole
{
    [Export(typeof(IPersistanceProvider))]
    public class DBPersistanceProvider : IPersistanceProvider
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void PersistProcessing(decimal persistanceID, string verificationCode)
        {
            using (var context = new RegiXAdapterConsoleContext())
            {
                context.OperationsPersistance.Add(
                    new DB.Entities.OperationsPersistance()
                    {
                        ApiServiceCallId = Convert.ToInt32(persistanceID),
                        VerificationCode = verificationCode
                    });
                context.SaveChanges();
            }
        }

        public void PersistResult(decimal persistanceID, ServiceResultData result)
        {
            using (var context = new RegiXAdapterConsoleContext())
            {
                var query = 
                    from op in context.OperationsPersistance
                   where op.ApiServiceCallId == persistanceID
                  select op;

                var persistedOperation = query.SingleOrDefault();
                if (persistedOperation!= null)
                {
                    persistedOperation.RawResult = result.XmlSerialize();
                }
                else
                {
                    log.Error($"Error persisintg result - persistaince with id {persistanceID} not found!");
                    throw new ApplicationException($"Persistance id {persistanceID} not found!");
                }
                context.SaveChanges();
            }
        }

        public void Remove(decimal persistanceID, string verificationCode)
        {
            using (var context = new RegiXAdapterConsoleContext())
            {
                var query =
                    from op in context.OperationsPersistance
                    where op.ApiServiceCallId == persistanceID
                    select op;

                var persistedOperation = query.SingleOrDefault();

                if (persistedOperation != null)
                {
                    if (persistedOperation.VerificationCode == verificationCode)
                    {
                        context.OperationsPersistance.Remove(persistedOperation);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new ApplicationException("Wrong verification code");
                    }
                }
                else
                {
                    throw new ApplicationException("No such service call id");
                }
            }
        }

        public ServiceResultData RetrieveResult(decimal persistanceID, string verificationCode)
        {
            using (var context = new RegiXAdapterConsoleContext())
            {
                var query =
                    from op in context.OperationsPersistance
                    where op.ApiServiceCallId == persistanceID
                    select op;

                var persistedOperation = query.SingleOrDefault();

                if (persistedOperation != null)
                {
                    if (persistedOperation.VerificationCode == verificationCode)
                    {
                        if (!string.IsNullOrEmpty(persistedOperation.RawResult))
                        {
                            return persistedOperation.RawResult.XmlDeserialize<ServiceResultData>();
                        }
                        else
                        {
                            return new ServiceResultData()
                            {
                                IsReady = false,
                                ServiceCallID = persistanceID
                            };
                        }
                    }
                    else
                    {
                        return new ServiceResultData()
                        {
                            HasError = true,
                            Error = "Wrong verification code"
                        };
                    }
                }
                else
                {
                    return new ServiceResultData()
                    {
                        HasError = true,
                        Error = $"There is no operation known with the provided id: {persistanceID}"
                    };
                }
            }
        }
    }
}
