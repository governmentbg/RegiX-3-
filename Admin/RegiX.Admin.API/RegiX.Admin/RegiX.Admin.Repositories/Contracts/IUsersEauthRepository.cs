using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Repositories.Contracts
{
    public interface IUsersEauthRepository : IBaseRepository<UsersEAuth, decimal, RegiXContext>
    {
    }
}
