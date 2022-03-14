using System.Collections.Generic;
using Microsoft.AspNet.OData.Query.Validators;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.EnumItemsToParameterTypes;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class EnumItemsToParameterTypesService :
        ABaseService<EnumItemsToParameterTypesInDto, EnumItemsToParameterTypesOutDto, EnumItemsToParameterTypes, int,RegiXClientContext>,
        IEnumItemsToParameterTypesService
    {
        public EnumItemsToParameterTypesService(IEnumItemsToParameterTypesRepository aBaseRepository) 
            : base(aBaseRepository)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("parameterType.id", "ParameterType/Id");
            dtoFieldsToEntityFields.Add("parameterType.displayName", "ParameterType/Type");
            dtoFieldsToEntityFields.Add("enum.id", "Enum/Id");
            dtoFieldsToEntityFields.Add("enum.displayName", "Enum/EnumDisplayText");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }

        
    }
}