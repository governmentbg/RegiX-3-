using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Register;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.QueryValidators;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class RegisterService : ABaseService<RegisterInDto, RegisterOutDto, Registers, int,RegiXClientContext>, IRegisterService
    {

        public RegisterService(IRegistersRepository aBaseRepository) 
            : base(aBaseRepository)
        {
            queryValidator = new RegistryQueryValidator();
        }
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("authority.id", "Authority/Id");
            dtoFieldsToEntityFields.Add("authority.displayName", "Authority/Name");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }

      
    }
}