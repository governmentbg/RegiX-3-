using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.RegisterObject;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="RegisterObjectService" />
    /// </summary>
    public class RegisterObjectService :
        ABaseService<RegisterObjectInDto, RegisterObjectOutDto, RegisterObjects, decimal, RegiXContext>,
        IRegisterObjectService
    {
        public RegisterObjectService(IRegisterObjectsRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("registerAdapter.id", "RegisterAdapter/RegisterAdapterId");
            dtoFieldsToEntityFields.Add("registerAdapter.displayName", "RegisterAdapter/Name");
            dtoFieldsToEntityFields.Add("id", "RegisterObjectId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}