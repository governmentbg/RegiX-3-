using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AccessReportFilterConsumer;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IAccessReportFilterConsumerService : IBaseService<AccessReportFilterConsumerInDto, AccessReportFilterConsumerOutDto, AccessReportFilterConsumerView, decimal>
    {
        
    }
}