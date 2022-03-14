using Microsoft.AspNet.OData.Query;
using System.Collections.Generic;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Authorities;
using TechnoLogica.RegiX.Client.Infrastructure.Models;

namespace TechnoLogica.RegiX.Client.Services.Contracts
{
    public interface IAuthoritiesService : IBaseService<AuthoritiesInDto, AuthoritiesOutDto, Authorities, int>
    {
        List<AuthoritiesOutDto> SelectAllProvidersNoWrap(ODataQueryOptions<Authorities> aQueryOptions);
        int GenerateReportsAndRoleForAuth(int authorityId);
    }
}