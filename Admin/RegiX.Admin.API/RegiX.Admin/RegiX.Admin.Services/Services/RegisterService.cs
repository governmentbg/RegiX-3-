using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.Register;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="RegisterService" />
    /// </summary>
    public class RegisterService : ABaseService<RegisterInDto, RegisterOutDto, Registers, decimal, RegiXContext>,
        IRegisterService
    {
        public RegisterService(IRegistersRepository aBaseRepository) : base(
            aBaseRepository, new RegistersQueryValidator())
        {
        }

        protected override void ValidateUpdate(Registers aRepoObj, RegisterInDto aInDto)
        {
            if (aRepoObj.AdministrationId != aInDto.AdministrationId)
                throw new Exception("Cannot update administrationId");
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
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