using AutoMapper;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.EnumItems;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.IoC.Configuration.Profiles
{
    public class EnumItemsProfile : Profile
    {
        public EnumItemsProfile()
        {
            // Configuration for EnumItems
            CreateMap<EnumItemsInDto, EnumItems>();
            CreateMap<EnumItems, EnumItemsOutDto>();
        }
    }
}