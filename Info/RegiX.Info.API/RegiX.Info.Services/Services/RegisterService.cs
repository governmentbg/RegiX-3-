using RegiX.Info.DataContracts.DTO.Registers;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using RegiX.Info.Services.QueryValidators;
using System.Collections.Generic;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class RegisterService : ABaseService<RegisterInDto, RegisterOutDto, Registers, decimal, RegiXContext>,
        IRegistersService
    {
        public RegisterService(IRegistersRepository aBaseRepository) 
            : base(aBaseRepository, new RegistersQueryValidator())
        {
        }



        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("administration.id", "Administration/AdministrationId");
            dtoFieldsToEntityFields.Add("administration.displayName", "Administration/Name");
            dtoFieldsToEntityFields.Add("id", "RegisterId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}