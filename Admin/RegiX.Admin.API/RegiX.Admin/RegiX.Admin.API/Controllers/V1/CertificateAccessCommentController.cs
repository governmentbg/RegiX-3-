using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateAccessComment;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Services.Contracts;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/certificate-access-comments")]//required for default versioning
    [Route("api/v{version:apiVersion}/certificate-access-comments")]
    [Authorize]
    public class CertificateAccessCommentController : ABaseController<CertificateAccessCommentInDto, CertificateAccessCommentOutDto, CertificateAccessComments, decimal>
    {
        public CertificateAccessCommentController(ICertificateAccessCommentService aBaseService) 
            : base(aBaseService)
        {
        }
    }
}
