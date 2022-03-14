using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.HealthServicePing;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="HealthServicePingService" />
    /// </summary>
    public class HealthServicePingService :
        ABaseService<HealthServicePingInDto, HealthServicePingOutDto, HealthServicePing, decimal, RegiXContext>,
        IHealthServicePingService
    {
        public HealthServicePingService(IHealthServicePingRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("id", "HealthServicePingId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}