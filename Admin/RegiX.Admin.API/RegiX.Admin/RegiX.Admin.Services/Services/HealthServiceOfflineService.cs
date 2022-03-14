using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServiceOffline;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="HealthServiceOfflineService" />
    /// </summary>
    public class HealthServiceOfflineService :
        ABaseService<HealthServiceOfflineInDto, HealthServiceOfflineOutDto, HealthServiceOffline, decimal, RegiXContext
        >,
        IHealthServiceOfflineService
    {
        public HealthServiceOfflineService(IHealthServiceOfflineRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("id", "HealthServiceOfflineId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}