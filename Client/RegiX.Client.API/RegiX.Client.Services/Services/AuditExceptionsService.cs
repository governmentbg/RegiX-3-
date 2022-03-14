using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditExceptions;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.QueryValidators;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class
        AuditExceptionsService : ABaseService<AuditExceptionsInDto, AuditExceptionsOutDto, AuditExceptions, int,RegiXClientContext> ,IAuditExceptionsService
    {
        public AuditExceptionsService(IAuditExceptionsRepository aBaseRepository) 
            : base(aBaseRepository, new AuditExceptionsQueryValidator())
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("authority.id", "Authority/Id");
            dtoFieldsToEntityFields.Add("authority.displayName", "Authority/Name");
            dtoFieldsToEntityFields.Add("user.id", "User/Id");
            dtoFieldsToEntityFields.Add("user.displayName", "User/UserName");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }
    }
}