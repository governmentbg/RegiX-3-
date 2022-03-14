using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateAccessComment;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface ICertificateAccessCommentService : IBaseService<CertificateAccessCommentInDto,
        CertificateAccessCommentOutDto, CertificateAccessComments, decimal>
    {
    }
}