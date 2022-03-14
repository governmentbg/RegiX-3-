using Microsoft.AspNet.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.DataContracts;
using TechnoLogica.API.Repositories.Contracts;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Repositories.Contracts;
using TechnoLogica.RegiX.Admin.Services.Contracts;
using TechnoLogica.RegiX.Admin.Services.QueryValidators;

namespace TechnoLogica.RegiX.Admin.Services.Services
{
    /// <summary>
    ///     Defines the <see cref="AdministrationServices" />
    /// </summary>
    public class AdministrationServices :
        ABaseService<AdministrationInDto, AdministrationOutDto, Administrations, decimal, RegiXContext>,
        IAdministrationService
    {
        /// <summary>
        ///     Defines the _administrationTypeRepository
        /// </summary>
        private readonly IAdministrationTypesRepository _administrationTypeRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdministrationServices" /> class.
        /// </summary>
        /// <param name="aBaseRepository">The aBaseRepository<see cref="IBaseRepository{Administrations}" /></param>
        /// <param name="aAdministrationTypeRepository">
        ///     The aAdministrationTypeRepository
        ///     <see cref="IAdministrationTypesRepository" />
        /// </param>
        public AdministrationServices(IAdministrationsRepository aBaseRepository,
            IAdministrationTypesRepository aAdministrationTypeRepository)
            : base(aBaseRepository, new AdministrationQueryValidator())
        {
            _administrationTypeRepository = aAdministrationTypeRepository;
            //_administrationTypeRepository.SetDbContext(this._baseRepository.GetDbContext());
        }

        /// <summary>
        ///     The Insert
        /// </summary>
        /// <param name="aInDto">The aInDto<see cref="AdministrationInDto" /></param>
        /// <returns>The <see cref="AdministrationOutDto" /></returns>
        public override AdministrationOutDto Insert(AdministrationInDto aInDto)
        {
            var administrationTypeId = aInDto.AdministrationTypeId;
            var parentAuthorityId = aInDto.ParentAuthorityId;
            ValidateAdministrationTypeId(administrationTypeId);
            ValidateParentAuthorityId(parentAuthorityId);

            return base.Insert(aInDto);
        }

        /// <summary>
        ///     The Update
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal" /></param>
        /// <param name="aInDto">The aInDto<see cref="AdministrationInDto" /></param>
        /// <returns>The <see cref="AdministrationOutDto" /></returns>
        public override AdministrationOutDto Update(decimal aId, AdministrationInDto aInDto)
        {
            var administrationTypeId = aInDto.AdministrationTypeId;
            var parentAuthorityId = aInDto.ParentAuthorityId;
            if (aId == aInDto.ParentAuthorityId)
                throw new Exception("ID of administration and parentAuthorityId cannot be the same!");

            ValidateAdministrationTypeId(administrationTypeId);
            ValidateParentAuthorityId(parentAuthorityId);

            return base.Update(aId, aInDto);
        }

        /// <summary>
        ///     The ValidateParentAuthorityId
        /// </summary>
        /// <param name="parentAuthorityId">The parentAuthorityId<see cref="decimal?" /></param>
        private void ValidateParentAuthorityId(decimal? parentAuthorityId)
        {
            if (parentAuthorityId != null)
            {
                var administration = _baseRepository.Select((decimal) parentAuthorityId);
                if (administration == null)
                {
                    var exceptionMessage = "Object of type Administration with " + administration.AdministrationId +
                                           " not exists!";
                    throw new Exception(exceptionMessage);
                }
            }
        }

        /// <summary>
        ///     The ValidateAdministrationTypeId
        /// </summary>
        /// <param name="administrationTypeId">The administrationTypeId<see cref="decimal?" /></param>
        private void ValidateAdministrationTypeId(decimal? administrationTypeId)
        {
            if (administrationTypeId != null)
            {
                var administrationType = _administrationTypeRepository.Select((decimal) administrationTypeId);
                if (administrationType == null)
                {
                    var exceptionMessage = "Object of type AdministrationType with " +
                                           administrationType.AdministrationTypeId + " not exists!";
                    throw new Exception(exceptionMessage);
                }
            }
        }

        /// <summary>
        ///     The PopulateDtoToEntityFieldsMapping
        /// </summary>
        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("administrationType.id", "AdministrationType/AdministrationTypeId");
            dtoFieldsToEntityFields.Add("administrationType.displayName", "AdministrationType/Name");
            dtoFieldsToEntityFields.Add("parentAuthority.id", "ParentAuthority/AdministrationId");
            dtoFieldsToEntityFields.Add("parentAuthority.displayName", "ParentAuthority/Name");
            dtoFieldsToEntityFields.Add("id", "AdministrationId");
        }

        protected override bool IsChildRecord(decimal aId, List<string> aParentsList)
        {
            return false;
        }

        public List<AdministrationOutDto> SelectAllPrimariesAnonymous(ODataQueryOptions<Administrations> aOptions)
        {
            IQueryable<Administrations> query = (this._baseRepository as IAdministrationsRepository).SelectAllPrimariesAnonymous();
            var resultQuery = this.ApplyOData(query, aOptions);
            // Връща query обект от repository-то
            List<Administrations> repoList = ((IQueryable<Administrations>)resultQuery).ToList();
            return MappingTools.MapToList<Administrations, AdministrationOutDto>(repoList);
        }

        public List<AdministrationOutDto> SelectAllPrimaries(ODataQueryOptions<Administrations> aOptions)
        {
            IQueryable<Administrations> query = (this._baseRepository as IAdministrationsRepository).SelectAllPrimaries();
            var resultQuery = this.ApplyOData(query, aOptions);
            // Връща query обект от repository-то
            List<Administrations> repoList = ((IQueryable<Administrations>)resultQuery).ToList();
            return MappingTools.MapToList<Administrations, AdministrationOutDto>(repoList);
        }

        public CustomPageResult<AdministrationOutDto> SelectAllPrimariesWithPagination(ODataQueryOptions<Administrations> aOptions)
        {
            IQueryable<Administrations> baseQuery = (this._baseRepository as IAdministrationsRepository).SelectAllPrimaries();
            var resultQuery = this.ApplyOData(baseQuery, aOptions);
            return this.CreatePageResult(aOptions, baseQuery, (IQueryable<Administrations>)resultQuery);
        }

        public bool IsPrimary(decimal administrationID)
        {
            IQueryable<Administrations> query = (this._baseRepository as IAdministrationsRepository).SelectAllPrimaries();
            return query.Where(a => a.AdministrationId == administrationID).Count() == 1;
        }
    }
}