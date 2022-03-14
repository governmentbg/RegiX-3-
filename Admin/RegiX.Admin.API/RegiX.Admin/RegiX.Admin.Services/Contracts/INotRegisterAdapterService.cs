using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface INotRegisterAdapterService
    {
        void InsertRegisterAdapter(RegisterAdapters adapter, ApiServices apiServices);
    }
}