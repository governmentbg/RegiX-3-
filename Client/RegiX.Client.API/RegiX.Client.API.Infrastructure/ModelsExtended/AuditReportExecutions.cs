using Microsoft.AspNet.OData.Query;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    [OrderBy]
    [Page(MaxTop = Constants.MaxPageSize)]
    public partial class AuditReportExecutions : IAuthorityIDFilter, IUserIDFilter
    {
        int? IAuthorityIDFilter.AuthorityId
        {
            get => this.AuthorityId;
            set => throw new System.NotImplementedException();
        }
        int? IUserIDFilter.UserId { 
            get => this.UserId; 
            set => throw new System.NotImplementedException(); 
        }
    }
}