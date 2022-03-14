using System.Collections.Generic;
using Microsoft.AspNet.OData.Query;
using RegiX.Info.API.DTOs.Administrations;
using RegiX.Info.Infrastructure.Models;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Contracts
{
    public interface IAdministrationsService : IBaseService<AdministrationsInDto, AdministrationsOutDto, Administrations, decimal>
    {
        List<AdministrationsOutDto> SelectAllPrimaries(ODataQueryOptions<Administrations> aOptions);
    }
}