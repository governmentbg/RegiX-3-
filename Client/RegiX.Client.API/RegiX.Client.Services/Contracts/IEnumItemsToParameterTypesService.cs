using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.EnumItemsToParameterTypes;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IEnumItemsToParameterTypesService : IBaseService<EnumItemsToParameterTypesInDto,
        EnumItemsToParameterTypesOutDto, EnumItemsToParameterTypes, int>
    {
    }
}