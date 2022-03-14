using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.OperationsErrorLog;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="OperationsErrorLogService" />
    /// </summary>
    public class OperationsErrorLogService :
        ABaseService<OperationsErrorLogInDto, OperationsErrorLogOutDto, OperationsErrorLog, decimal, RegiXContext>,
        IOperationsErrorLogService
    {
        public OperationsErrorLogService(IOperationsErrorLogRepository aBaseRepository)
            : base(aBaseRepository,new OperationsErrorLogQueryValidator())
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/AdapterOperationId");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/Name");

            dtoFieldsToEntityFields.Add("apiServiceCall.id", "ApiServiceCall/ApiServiceCallId");
            dtoFieldsToEntityFields.Add("apiServiceCall.displayName", "ApiServiceCall/ApiServiceOperation/ApiService/Name");

            dtoFieldsToEntityFields.Add("apiServiceOperations.id", "ApiServiceOperation/ApiServiceOperationId");
            dtoFieldsToEntityFields.Add("apiServiceOperations.displayName", "ApiServiceOperation/Name");

            dtoFieldsToEntityFields.Add("apiServiceConsumer.id", "ApiServiceCall/ConsumerCertificate/ApiServiceConsumer/ApiServiceConsumerId");
            dtoFieldsToEntityFields.Add("apiServiceConsumer.displayName", "ApiServiceCall/ConsumerCertificate/ApiServiceConsumer/Name");

            dtoFieldsToEntityFields.Add("administration.id", "ApiServiceCall/ConsumerCertificate/ApiServiceConsumer/Administration/AdministrationId");
            dtoFieldsToEntityFields.Add("administration.displayName", "ApiServiceCall/ConsumerCertificate/ApiServiceConsumer/Administration/Name");

            dtoFieldsToEntityFields.Add("consumerCertificate.id", "ApiServiceCall/ConsumerCertificate/ConsumerCertificateId");
            dtoFieldsToEntityFields.Add("consumerCertificate.displayName", "ApiServiceCall/ConsumerCertificate/Name");

            dtoFieldsToEntityFields.Add("id", "OperationsErrorLogId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}