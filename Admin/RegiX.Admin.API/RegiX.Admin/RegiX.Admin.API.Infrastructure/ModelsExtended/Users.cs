using Microsoft.AspNet.OData.Query;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.Filters;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    [OrderBy]
    [Page(MaxTop = Constants.MaxPageSize)]
    public partial class Users : IAdministrationIDFilter
    {
    }
}