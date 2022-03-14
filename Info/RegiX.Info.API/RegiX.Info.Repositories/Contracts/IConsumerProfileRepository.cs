using RegiX.Info.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Repositories.Contracts;

namespace RegiX.Info.Repositories.Contracts
{
    public interface IConsumerProfileRepository : IBaseRepository<ConsumerProfiles, decimal, RegiXContext>
    {
    }
}
