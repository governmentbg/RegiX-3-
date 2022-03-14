using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.ParameterToOperation;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class ParameterToOperationService :
        ABaseService<ParameterToOperationInDto, ParameterToOperationOutDto, ParametersToOperation, int,RegiXClientContext>,
        IParameterToOperationService
    {
        public ParameterToOperationService(IParametersToOperationsRepository aBaseRepository) 
            : base(aBaseRepository)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("parameter.id", "Parameter/Id");
            dtoFieldsToEntityFields.Add("parameter.displayName", "Parameter/DisplayOperationName");
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/Id");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/OperationName");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }

      
    }
}