using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Repositories.Impl;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    public class NotRegisterAdapterService : INotRegisterAdapterService
    {
        private readonly IRegisterAdaptersRepository repoAdapter;
        
        public NotRegisterAdapterService(IRegisterAdaptersRepository repoAdapter)
        {
            this.repoAdapter = repoAdapter;

        }

        public void InsertRegisterAdapter(RegisterAdapters adapter, ApiServices apiServices)
        {
            repoAdapter.Insert(adapter, apiServices);
        }
    }
}