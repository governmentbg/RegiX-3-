using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.Authentication.Common
{
    public interface IDataProtectionKeyStoreProvider
    {
        IDataProtectionBuilder AddPersistance(IDataProtectionBuilder builder, IConfiguration configuration, ILoggerFactory loggerFactory);
    }
}
