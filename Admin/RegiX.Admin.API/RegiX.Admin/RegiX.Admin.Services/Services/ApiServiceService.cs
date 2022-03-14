using System;
using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApiService;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="ApiServiceService" />
    /// </summary>
    public class ApiServiceService :
        ABaseService<ApiServiceInDto, ApiServiceOutDto, ApiServices, decimal, RegiXContext>,
        IApiServiceService
    {
        public ApiServiceService(IApiServicesRepository aBaseRepository)
            : base(aBaseRepository, new ApiServicesQueryValidator())
        {
        }

        protected override void ValidateUpdate(ApiServices repoObj, ApiServiceInDto aInDto)
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
            dtoFieldsToEntityFields.Add("id", "ApiServiceId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}