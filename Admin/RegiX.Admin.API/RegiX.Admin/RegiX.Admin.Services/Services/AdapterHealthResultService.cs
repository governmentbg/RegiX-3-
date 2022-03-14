using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.AdapterHealthResult;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="AdapterHealthResultService" />
    /// </summary>
    public class AdapterHealthResultService :
        ABaseService<AdapterHealthResultInDto, AdapterHealthResultOutDto, AdapterHealthResults, decimal, RegiXContext>,
        IAdapterHealthResultService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdapterHealthResultService" /> class.
        /// </summary>
        /// <param name="aBaseRepository">The aBaseRepository<see cref="IBaseRepository{AdapterHealthResults}" /></param>
        /// <param name="aDbContext">The aDbContext<see cref="RegiXContext" /></param>
        public AdapterHealthResultService(IAdapterHealthResultsRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("adapterHealthFunction.id", "AdapterHealthFunction/AdapterHealthFunctionId");
            dtoFieldsToEntityFields.Add("adapterHealthFunction.displayName", "AdapterHealthFunction/Description");
            dtoFieldsToEntityFields.Add("registerAdapter.id", "RegisterAdapter/RegisterAdapterId");
            dtoFieldsToEntityFields.Add("registerAdapter.displayName", "RegisterAdapter/Name");
            dtoFieldsToEntityFields.Add("id", "AdapterHealthResultId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}