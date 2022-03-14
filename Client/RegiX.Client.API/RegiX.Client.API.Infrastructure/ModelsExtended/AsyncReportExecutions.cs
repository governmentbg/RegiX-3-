using Microsoft.AspNet.OData.Query;
using System;
using System.Collections.Generic;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    [OrderBy]
    [Page(MaxTop = Constants.MaxPageSize)]
    public partial class AsyncReportExecutions : IUserIDFilter
    {
    }
}