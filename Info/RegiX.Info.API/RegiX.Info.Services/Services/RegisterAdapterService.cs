using System.Collections.Generic;
using Microsoft.AspNet.OData.Query.Validators;
using RegiX.Info.DataContracts.DTO.RegisterAdapter;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Services.Contracts;
using RegiX.Info.Services.QueryValidators;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class RegisterAdapterService :
        ABaseService<RegisterAdapterInDto, RegisterAdapterOutDto, RegisterAdapters, decimal, RegiXContext>,
        IRegisterAdapterService
    {
        public RegisterAdapterService(IBaseRepository<RegisterAdapters, decimal, RegiXContext> aBaseRepository) 
            : base(aBaseRepository, new RegisterAdapterQueryValidator())
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("register.id", "Register/RegisterId");
            dtoFieldsToEntityFields.Add("register.displayName", "Register/Name");
            dtoFieldsToEntityFields.Add("id", "RegisterAdapterId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }
    }
}