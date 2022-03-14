using Microsoft.AspNet.OData.Query.Validators;
using RegiX.Info.API.DTOs.Administrations;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;
using RegiX.Info.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData.Query;
using TechnoLogica.API.Services;

namespace RegiX.Info.Services.Services
{
    public class AdministrationsService : ABaseService<AdministrationsInDto, AdministrationsOutDto, Administrations, decimal,
            RegiXContext>,
    IAdministrationsService
    {
        public AdministrationsService(IAdministrationRepository aBaseRepository, FilterQueryValidator aQueryValidator = null) : base(aBaseRepository, aQueryValidator)
        {
        }

        public List<AdministrationsOutDto> SelectAllPrimaries(ODataQueryOptions<Administrations> aOptions)
        {
            IQueryable<Administrations> query = (this._baseRepository as IAdministrationRepository).SelectAllPrimaries();
            var resultQuery = this.ApplyOData(query, aOptions);
            // Връща query обект от repository-то
            List<Administrations> repoList = ((IQueryable<Administrations>)resultQuery).ToList();
            return MappingTools.MapToList<Administrations, AdministrationsOutDto>(repoList);
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }
    }
}