using System;
using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiServiceConsumer;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="ApiServiceConsumerService" />
    /// </summary>
    public class ApiServiceConsumerService :
        ABaseService<ApiServiceConsumerInDto, ApiServiceConsumerOutDto, ApiServiceConsumers, decimal, RegiXContext>,
        IApiServiceConsumerService
    {
        public ApiServiceConsumerService(IApiServiceConsumersRepository aBaseRepository)
            : base(aBaseRepository)
        {
            this.queryValidator = new ApiServiceConsumerQueryValidator();
        }

        protected override void ValidateUpdate(ApiServiceConsumers repoObj, ApiServiceConsumerInDto aInDto)
        {
            if (repoObj.AdministrationId != aInDto.AdministrationId)
                throw new Exception("Cannot update administrationId");
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("administration.id", "Administration/AdministrationId");
            dtoFieldsToEntityFields.Add("administration.displayName", "Administration/Name");
            dtoFieldsToEntityFields.Add("id", "ApiServiceConsumerId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}