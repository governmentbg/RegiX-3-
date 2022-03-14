using System;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CustomParameter;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="CustomParameterService" />
    /// </summary>
    public class CustomParameterService :
        ABaseService<CustomParameterInDto, CustomParameterOutDto, CustomParameters, decimal, RegiXContext>,
        ICustomParameterService
    {
        public CustomParameterService(ICustomParametersRepository aBaseRepository)
            : base(aBaseRepository)
        {
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("report.id", "Report/ReportId");
            dtoFieldsToEntityFields.Add("report.displayName", "Report/Name");
            dtoFieldsToEntityFields.Add("operationParameter.id", "OperationParameter/Id");
            dtoFieldsToEntityFields.Add("operationParameter.displayName", "OperationParameter/Name");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }
    }
}