using Microsoft.AspNet.OData.Query;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    [OrderBy]
    [Page(MaxTop = Constants.MaxPageSize)]
    public partial class UsersToReports : IUserIDFilter
    {
        int? IUserIDFilter.UserId { get => this.UserId; set => throw new System.NotImplementedException(); }
    }
}