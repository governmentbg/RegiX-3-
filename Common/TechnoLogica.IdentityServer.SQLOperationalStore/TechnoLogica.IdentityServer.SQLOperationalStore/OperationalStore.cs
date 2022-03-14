using System;
using System.Collections.Generic;
using System.Text;

namespace TechnoLogica.IdentityServer.SQLOperationalStore
{
    public class OperationalStore
    {
        public string DataProtectionConnectionStringName { get; set; }
        public string DistributedCacheConnectionStringName { get; set; }
        public string ConnectionStringName { get; set; }
        public bool EnableClenaup { get; set; }
        public int CleanupInterval { get; set; }
    }
}
