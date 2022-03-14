using RegiX.Adapters.Mocks;
using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.Adapters.Mocks.Tests2
{
    public interface IOtherAdapterServiceNETCore : IAdapterService
    {

    }
    public class DummyTestAdapterServiceNETCoreMock2 : BaseAdapterServiceProxy<IOtherAdapterServiceNETCore>
    {
    }
}
