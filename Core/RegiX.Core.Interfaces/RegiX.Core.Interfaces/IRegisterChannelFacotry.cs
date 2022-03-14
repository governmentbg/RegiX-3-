using TechnoLogica.RegiX.Common;

namespace TechnoLogica.RegiX.Core.Interfaces
{
    public interface IRegisterChannelFacotry<I>
        where I : IAdapterService
    {
        I CreateChannel();
    }
}
