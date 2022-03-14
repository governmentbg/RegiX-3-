using Microsoft.AspNet.OData.Query.Validators;
using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AccessReportFilter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class AccessReportFilterService :
        ABaseService<AccessReportFilterInDto, AccessReportFilterOutDto, AccessReportFilterView, decimal, RegiXContext>,
        IAccessReportFilterService
    {
        public AccessReportFilterService(IAccessReportFilterRepository aBaseRepository, FilterQueryValidator aQueryValidator = null) 
            : base(aBaseRepository, aQueryValidator)
        {
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false ;
        }
    }
}