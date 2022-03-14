using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.Report;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="ReportService" />
    /// </summary>
    public class ReportService : ABaseService<ReportInDto, ReportOutDto, Reports, decimal, RegiXContext>, IReportService
    {
        public ReportService(IReportsRepository aBaseRepository) : base(aBaseRepository)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("apiServiceConsumer.id", "ApiServiceConsumer/ApiServiceConsumerId");
            dtoFieldsToEntityFields.Add("apiServiceConsumer.displayName", "ApiServiceConsumer/Name");
            dtoFieldsToEntityFields.Add("apiServiceOperation.id", "ApiServiceOperation/ApiServiceOperationId");
            dtoFieldsToEntityFields.Add("apiServiceOperation.displayName", "ApiServiceOperation/Name");
            dtoFieldsToEntityFields.Add("id", "ReportId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}