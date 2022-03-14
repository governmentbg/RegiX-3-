using Microsoft.AspNet.OData.Query;
using TechnoLogica.API.DataContracts;
using TechnoLogica.RegiX.AdapterConsole.Infrastructure.Filters;

namespace TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models
{
    [OrderBy]
    [Page(MaxTop = Constants.MaxPageSize)]
    public partial class OperationCalls : IRoleFilter, IAssignedToFilter
    {
    }
}