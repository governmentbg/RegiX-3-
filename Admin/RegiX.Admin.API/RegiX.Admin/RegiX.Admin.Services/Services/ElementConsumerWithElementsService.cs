using Microsoft.AspNet.OData.Query.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ElementConsumer;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ElementConsumerWithElementsService :
        ABaseService<ElementConsumerWithElementsInDto, ElementConsumerWithElementsOutDto,
        GetElementConsumersElementsViewOutput, decimal, RegiXContext>,
        IElementConsumerWithElementsService
    {

        public ElementConsumerWithElementsService(IElementConsumerWithElementsRepository elementConsumerRepository, FilterQueryValidator aQueryValidator = null)
            : base(elementConsumerRepository, aQueryValidator)
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
