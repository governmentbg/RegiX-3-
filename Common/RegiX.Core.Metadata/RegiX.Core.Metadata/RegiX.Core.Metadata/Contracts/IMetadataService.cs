using RegiX.Core.Metadata.Services;
using System.Collections.Generic;
using RegiX.Core.Metadata.Models;
using TechnoLogica.RegiX.Core.Data.Interfaces;
using TechnoLogica.RegiX.Core.Data.Interfaces.Models;

namespace RegiX.Core.Metadata
{
    public interface IMetadataService
    {
        IEnumerable<AdapterVersion> GetRegisteredAdapters();
        IEnumerable<AdapterVersion> GetNotRegisteredAdapters();
        IEnumerable<AdapterVersion> GetRegisteredAdaptersWithDiffVersions();
        IEnumerable<Adapter> GetFullAdapterInformation(string adapterFullName);
        IEnumerable<AdapterInfo> GetAdaptersInfo();
        AdapterDataDto GetAllAdapterData(string adapterName);
    }
}
