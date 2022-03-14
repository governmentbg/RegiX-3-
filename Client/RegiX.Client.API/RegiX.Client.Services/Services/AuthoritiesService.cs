using Microsoft.AspNet.OData.Query;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Authorities;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class AuthoritiesService : ABaseService<AuthoritiesInDto, AuthoritiesOutDto, Authorities, int, RegiXClientContext>,
        IAuthoritiesService
    {
        public AuthoritiesService(IAuthoritiesRepository aBaseRepository) 
            : base(aBaseRepository)
        {
        }

        public List<AuthoritiesOutDto> SelectAllProvidersNoWrap(ODataQueryOptions<Authorities> aQueryOptions)
        {
            var resultQuery = _baseRepository
                .SelectAll()
                .Where(elem => elem.Registers.Count > 0);


            var repoList = resultQuery.ToList();
            return MappingTools.MapToList<Authorities, AuthoritiesOutDto>(repoList);
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("parentAuthority.id", "ParentAuthority/Id");
            dtoFieldsToEntityFields.Add("parentAuthority.displayName", "ParentAuthority/Name");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }

        public int GenerateReportsAndRoleForAuth(int authorityId)
        {
            return ((IAuthoritiesRepository)_baseRepository).GenerateReportsAndRoleForAuth(authorityId);
        }
    }
}