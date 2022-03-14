using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.AdapterConsole.DataContracts.AdapterOperation;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models;
using TechnoLogica.RegiX.AdapterConsole.Repositories;
using TechnoLogica.RegiX.AdapterConsole.Services.Contracts;

namespace TechnoLogica.RegiX.AdapterConsole.Services.Impl
{
    public class AdapterOperationsService :
        ABaseService<AdapterOperationsInDto, AdapterOperationsOutDto, AdapterOperations, int, RegiXAdapterConsoleContext
        >, IAdapterOperationsService
    {
        private readonly IAdapterOperationsRepository _aBaseRepository;

        public AdapterOperationsService(IAdapterOperationsRepository aBaseRepository)
            : base(aBaseRepository)
        {
            _aBaseRepository = aBaseRepository;
        }

        public IQueryable<AdapterOperations> GetUsersAdapterOperationsById(int userId)
        {
            return _aBaseRepository.SelectByUser(userId);
        }


        /// <summary>
        ///   The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}