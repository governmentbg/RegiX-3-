using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoLogica.RegiX.Core.Helpers.Interfaces
{
    public enum ExpectedSSLCertificatePlace
    {
        HeaderOnly,
        RequestOnly,
        HeaderRequest,
        RequestHeader,
        ThumbprintFromHeader,
        Nowhere
    }
}
