using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.EnumItems;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IEnumItemsService : IBaseService<EnumItemsInDto, EnumItemsOutDto, EnumItems, int>
    {
    }
}