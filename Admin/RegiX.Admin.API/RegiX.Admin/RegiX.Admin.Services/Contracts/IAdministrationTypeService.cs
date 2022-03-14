using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdministrationType;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IAdministrationTypeService : IBaseService<AdministrationTypeInDto, AdministrationTypeOutDto,
        AdministrationTypes, decimal>
    {
    }
}