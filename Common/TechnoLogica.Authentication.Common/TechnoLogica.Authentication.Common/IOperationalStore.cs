using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.Authentication.Common
{
    public interface IOperationalStore
    {
        void AddOperationalStore(IIdentityServerBuilder builder, IConfiguration configuration);
    }
}
