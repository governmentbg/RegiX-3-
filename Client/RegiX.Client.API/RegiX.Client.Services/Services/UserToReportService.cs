using Microsoft.AspNet.OData.Query.Validators;
using System.Collections.Generic;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToReport;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.QueryValidators;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class UserToReportService : ABaseService<UserToReportInDto, UserToReportOutDto, UsersToReports, int,RegiXClientContext>,
        IUserToReportService
    {
        public UserToReportService(IUsersToReportsRepository aBaseRepository) 
            : base(aBaseRepository)
        {
            queryValidator = new UsersToReportsQueryValidator();
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("user.id", "User/Id");
            dtoFieldsToEntityFields.Add("user.displayName", "User/UserName");
            dtoFieldsToEntityFields.Add("user.authorityId", "User/FederationUsers/UserAuthority/Id");
            dtoFieldsToEntityFields.Add("report.id", "Report/Id");
            dtoFieldsToEntityFields.Add("report.displayName", "Report/Name");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new System.NotImplementedException();
        }

        
    }
}