using RegiX.Info.DataContracts.DTO.ConsumerProfile;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IConsumerProfileService : IBaseService<ConsumerProfileInDto, ConsumerProfileOutDto, ConsumerProfiles, decimal>
    {
    }
}
