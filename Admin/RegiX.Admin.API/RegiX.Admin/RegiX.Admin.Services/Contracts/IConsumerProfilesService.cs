using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.ConsumerProfiles;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface IConsumerProfilesService : IBaseService<ConsumerProfilesInDto, ConsumerProfilesOutDto, ConsumerProfiles, decimal>
    {
        
    }
}