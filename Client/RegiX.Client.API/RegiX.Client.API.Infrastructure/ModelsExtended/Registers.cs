using Microsoft.AspNet.OData.Query;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    [OrderBy]
    [Page(MaxTop = Constants.MaxPageSize)]
    public partial class Registers : IAuthorityIDFilter
    {
        int? IAuthorityIDFilter.AuthorityId { get => this.AuthorityId; set => throw new System.NotImplementedException(); }
    }
}