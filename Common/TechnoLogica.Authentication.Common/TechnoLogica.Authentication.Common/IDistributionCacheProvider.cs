using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.Authentication.Common
{
    public interface IDistributionCacheProvider
    {
        void AddDistributedCache(IServiceCollection services, IConfiguration configuration);
    }
}
