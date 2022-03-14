using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Routing;
using TechnoLogica.API.Common.Controllers;
using TechnoLogica.RegiX.Admin.API.DataContracts.DTO.CertificateElementAccess;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Infrastructure;

namespace TechnoLogica.RegiX.Admin.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/certificate-element-access")]//required for default versioning
    [Route("api/v{version:apiVersion}/certificate-element-access")]
    [Authorize]
    public class CertificateElementAccessController : ABaseGetAllController<CertificateElementAccessInDto, CertificateElementAccessOutDto, CertificateElementAccess, decimal>
    {
        private IUserContext UserContext { get; set; }

        public CertificateElementAccessController(ICertificateElementAccessService aBaseService, IUserContext userContext) 
            : base(aBaseService)
        {
            UserContext = userContext;
        }

        public override IActionResult Post([FromBody] CertificateElementAccessInDto aInDto)
        {
            if (UserContext.UserId.HasValue)
            {
                aInDto.UserId = UserContext.UserId.Value;
            }
            else
            {
                throw new ApplicationException("There is no user in the context!");
            }

            return base.Post(aInDto);
        }
    }
}
