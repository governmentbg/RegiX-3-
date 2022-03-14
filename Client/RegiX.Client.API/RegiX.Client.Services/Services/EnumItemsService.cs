using System.Collections.Generic;
using Microsoft.AspNet.OData.Query.Validators;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.EnumItems;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class EnumItemsService : ABaseService<EnumItemsInDto, EnumItemsOutDto, EnumItems, int, RegiXClientContext>,
        IEnumItemsService
    {
        public EnumItemsService(IEnumItemsRepository aBaseRepository) 
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