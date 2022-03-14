using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Role;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.QueryValidators;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class RoleService : ABaseClearReportsService<RoleInDto, RoleOutDto, Roles>, IRoleService
    {
        private readonly IRolesToReportsRepository rolesToReportRepository;
        private readonly IUsersToRolesRepository usersToRolesRepository;
        private readonly IUserContext userContext;
        public RoleService
            (
                IRolesRepository aBaseRepository,
                IUsersFavouriteReportRepository aFavouriteReportsRepository,
                IReportsForUsersViewRepository aReportsForUserRepository,
                IDatabaseOperationsService aDatabaseOperationsService,
                IRolesToReportsRepository aRolesToReportRepository,
                IUsersToRolesRepository aUsersToRolesRepository,
                IUserContext aUserContext
            )
            : base(aBaseRepository, aFavouriteReportsRepository, aReportsForUserRepository, aDatabaseOperationsService)
        {
            rolesToReportRepository = aRolesToReportRepository;
            usersToRolesRepository = aUsersToRolesRepository;
            userContext = aUserContext;
            queryValidator = new RolesQueryValidator();
        }
        
        public override RoleOutDto Insert(RoleInDto aInDto)
        {
            try
            {
                var mappedObj = MappingTools.MapTo<RoleInDto, Roles>(aInDto);

                if (!userContext.IsGlobalAdmin)
                {
                    mappedObj.AuthorityId = userContext.AdministrationID;
                }
                else
                {
                    mappedObj.AuthorityId ??= userContext.AdministrationID;
                }

                mappedObj.CreatedOn = DateTime.Now;
                mappedObj.CreatedBy = this.userContext.UserName;

                var resultObj = _baseRepository.Insert(mappedObj);
                var reportIds = aInDto.ReportIds;
                foreach (var reportId in reportIds)
                {
                    var report = new RolesToReports {ReportId = reportId, Role = resultObj};
                    rolesToReportRepository.Insert(report);
                }

                var userIds = aInDto.UserIds;
                foreach (var userId in userIds)
                {
                    var userToRole = new UsersToRoles {UserId = userId, Role = resultObj};
                    usersToRolesRepository.Insert(userToRole);
                }

                _baseRepository.GetDbContext().SaveChanges();
                return MappingTools.MapTo<Roles, RoleOutDto>(resultObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override RoleOutDto Update(int aId, RoleInDto aInDto)
        {
            var repoObj = _baseRepository.Select(aId);
            if (repoObj == null) throw new Exception("Object with id [" + aId + "] not found!");
            try
            {
                repoObj = MappingTools.MapTo(aInDto, repoObj);

                repoObj.ModifiedOn = DateTime.Now;

                if (!userContext.IsGlobalAdmin)
                {
                    repoObj.AuthorityId = userContext.AdministrationID;
                }
                else
                {
                    repoObj.AuthorityId ??= userContext.AdministrationID;
                }

                repoObj.ModifiedBy = this.userContext.UserName;

                var resultObj = _baseRepository.Update(repoObj);

                //delete old users (only federation users deleted)
                var usersToReports = usersToRolesRepository
                    .SelectAll()
                    .Where(elem => elem.RoleId == aId && elem.User.FederationUsers.UserAuthorityId == aInDto.AuthorityId )
                    .ToList();
                usersToReports.ForEach(elem => { usersToRolesRepository.Delete(elem.Id); });

                //delete old reports
                var elements = rolesToReportRepository
                    .SelectAll()
                    .Where(elem => elem.RoleId == aId)
                    .ToList();
                elements.ForEach(elem => { rolesToReportRepository.Delete(elem.Id); });

                // insert new users
                var userIds = aInDto.UserIds;
                foreach (var userId in userIds)
                {
                    var roleUser = new UsersToRoles
                    {
                        UserId = userId,
                        RoleId = resultObj.Id,
                        CreatedOn = DateTime.Now,
                        CreatedBy = this.userContext.UserName
                    };

                    usersToRolesRepository.Insert(roleUser);
                }

                // insert new reports
                var reportIds = aInDto.ReportIds;
                foreach (var reportId in reportIds)
                {
                    var report = new RolesToReports
                    {
                        ReportId = reportId,
                        RoleId = resultObj.Id,
                        CreatedOn = DateTime.Now,
                        CreatedBy = this.userContext.UserName
                    };


                    rolesToReportRepository.Insert(report);
                }

                _baseRepository.GetDbContext().SaveChanges();
                ClearFavouriteReports();

                return MappingTools.MapTo<Roles, RoleOutDto>(resultObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("authority.id", "Authority/Id");
            dtoFieldsToEntityFields.Add("authority.displayName", "Authority/Name");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }
    }
}