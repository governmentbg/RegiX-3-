using Microsoft.AspNet.OData.Query;
using System;
using System.Collections.Generic;
using System.Text;
using TechnoLogica.API.DataContracts;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    [OrderBy]
    [Page(MaxTop = Constants.MaxPageSize)]
    public partial class CertificateConsumerRole
    {
    }
}
