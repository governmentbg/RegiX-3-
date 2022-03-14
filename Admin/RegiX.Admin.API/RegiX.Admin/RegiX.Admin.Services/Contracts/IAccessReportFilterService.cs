using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AccessReportFilter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IAccessReportFilterService : IBaseService<AccessReportFilterInDto, AccessReportFilterOutDto, AccessReportFilterView, decimal>
    {
        
    }
}