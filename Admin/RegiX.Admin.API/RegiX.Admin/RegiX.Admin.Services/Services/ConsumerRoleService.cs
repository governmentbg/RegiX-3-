using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerRole;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ConsumerRoleService :
        ABaseService<ConsumerRoleInDto, ConsumerRoleOutDto, ConsumerRoles, decimal, RegiXContext>,
        IConsumerRoleService
    {
        public ConsumerRoleService(IConsumerRolesRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }
    }
}
