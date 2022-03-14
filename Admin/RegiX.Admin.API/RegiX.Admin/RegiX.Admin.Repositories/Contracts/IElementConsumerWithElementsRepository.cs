using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts
{
    public interface IElementConsumerWithElementsRepository : IBaseRepository<GetElementConsumersElementsViewOutput, decimal, RegiXContext>
    {
    }
}
