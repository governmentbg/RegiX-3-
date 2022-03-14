using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.AuditValues;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IAuditValuesService : IBaseService<AuditValuesInDto, AuditValuesOutDto, AuditValues, int>
    {
    }
}