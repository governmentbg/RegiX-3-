using System;

namespace TechnoLogica.RegiX.Core.Data.Interfaces
{
    public interface ICertificateInfo
    {
        DateTime? ValidFrom { get; set; }
        DateTime? ValidTo { get; set; }
        bool Active { get; set; }
    }
}