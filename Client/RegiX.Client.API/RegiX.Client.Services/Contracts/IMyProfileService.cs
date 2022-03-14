using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.MyProfileDtos;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IMyProfileService : IBaseService<MyProfileInDto, MyProfileOutDto, Users, int>
    {
    }
}