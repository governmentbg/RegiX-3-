using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ApprovedRequestElements;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IApprovedRequestElementsService : IBaseService<ApprovedRequestElementsInDto,
        ApprovedRequestElementsOutDto, ApprovedRequestElements, decimal>
    {
        
    }
}