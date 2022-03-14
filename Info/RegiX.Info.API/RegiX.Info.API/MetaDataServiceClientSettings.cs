using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegiX.Info.API
{
    public class MetaDataServiceClientSettings
    {
        public string EndpointAddress { get; set; }
        public int RetryIntervalSeconds { get; set; }
    }
}
