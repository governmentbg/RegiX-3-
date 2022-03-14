using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.ParameterType;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class ParameterTypeService : ABaseService<ParameterTypeInDto, ParameterTypeOutDto, ParameterTypes, int,RegiXClientContext>,
        IParameterTypeService
    {
        public ParameterTypeService(IParameterTypesRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }

      
    }
}