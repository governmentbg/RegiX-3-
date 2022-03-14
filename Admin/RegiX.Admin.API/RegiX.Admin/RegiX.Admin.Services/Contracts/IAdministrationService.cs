using Microsoft.AspNet.OData.Query;
using System.Collections.Generic;
using TechnoLogica.API.DataContracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;

namespace TechnoLogica.RegiX.Admin.Services.Contracts
{
    public interface
        IAdministrationService : IBaseService<AdministrationInDto, AdministrationOutDto, Administrations, decimal>
    {
        List<AdministrationOutDto> SelectAllPrimariesAnonymous(ODataQueryOptions<Administrations> aOptions);

        List<AdministrationOutDto> SelectAllPrimaries(ODataQueryOptions<Administrations> aOptions);

        CustomPageResult<AdministrationOutDto> SelectAllPrimariesWithPagination(ODataQueryOptions<Administrations> aOptions);

        bool IsPrimary(decimal administrationID);
    }
}