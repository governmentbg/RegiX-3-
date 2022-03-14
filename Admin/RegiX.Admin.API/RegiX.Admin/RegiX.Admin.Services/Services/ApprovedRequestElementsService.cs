using System.Collections.Generic;
using Microsoft.AspNet.OData.Query.Validators;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApprovedRequestElements;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class ApprovedRequestElementsService :
        ABaseService<ApprovedRequestElementsInDto, ApprovedRequestElementsOutDto, ApprovedRequestElements, decimal, RegiXContext>,
        IApprovedRequestElementsService
    {
        public ApprovedRequestElementsService(IBaseRepository<ApprovedRequestElements, decimal, RegiXContext> aBaseRepository, FilterQueryValidator aQueryValidator = null) : base(aBaseRepository, aQueryValidator)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("registerObjectElement.id", "RegisterObjectElement/RegisterObjectElementId");
            dtoFieldsToEntityFields.Add("registerObjectElement.displayName", "RegisterObjectElement/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}