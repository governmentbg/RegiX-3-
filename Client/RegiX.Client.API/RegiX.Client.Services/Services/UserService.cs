using System;
using System.Collections.Generic;
using System.Linq;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.User;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.QueryValidators;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class UserService : ABaseClearReportsService<UserInDto, UserOutDto, Users>, IUserService
    {
        private readonly IUsersToReportsRepository usersToReportsRepository;
        private readonly IFederationUsersRepository aFederationUsersRepository;
        private readonly IUserContext userContext;
        private readonly IUsersToRolesRepository usersToRolesRepository;

        public UserService
        (
            IUsersRepository aBaseRepository,
            IUsersFavouriteReportRepository aFavouriteReportsRepository,
            IReportsForUsersViewRepository aReportsForUserRepository,
            IDatabaseOperationsService aDatabaseOperationsService,
            IUsersToRolesRepository aUsersToRolesRepository,
            IUsersToReportsRepository aUsersToReportsRepository,
            IFederationUsersRepository aFederationUsersRepository,
            IUserContext aUserContext
        )
            : base(aBaseRepository, aFavouriteReportsRepository, aReportsForUserRepository, aDatabaseOperationsService)
        {
            usersToReportsRepository = aUsersToReportsRepository;
            this.aFederationUsersRepository = aFederationUsersRepository;
            this.userContext = aUserContext;
            usersToRolesRepository = aUsersToRolesRepository;
            queryValidator = new UsersQueryValidator();
        }
        //public UserService(IBaseRepository<Users, int,RegiXClientContext> aBaseRepository,
        //    IUsersToRolesRepository aUsersToRolesRepository,
        //    IUsersToReportsRepository aUsersToReportsRepository,
        //    IUsersFavouriteReportRepository aFavouriteReportsRepository,
        //    IReportsForUsersViewRepository aReportsForUserRepository,
        //    IDatabaseOperationsService aDatabaseOperationsService, FilterQueryValidator aQueryValidator
        //    )
        //    : base(aBaseRepository,
        //        aFavouriteReportsRepository,
        //        aReportsForUserRepository,
        //        aDatabaseOperationsService,
        //        aQueryValidator
        //        )
        //{
        //    usersToReportsRepository = aUsersToReportsRepository;
        //    usersToRolesRepository = aUsersToRolesRepository;
        //}

        public override UserOutDto Insert(UserInDto aInDto)
        {
            try
            {
                var mappedObj = MappingTools.MapTo<UserInDto, Users>(aInDto);

                var resultObj = _baseRepository.Insert(mappedObj);
                var reportIds = aInDto.ReportIds;
                foreach (var reportId in reportIds)
                {
                    var report = new UsersToReports();
                    report.ReportId = reportId;
                    report.UserId = resultObj.Id;

                    usersToReportsRepository.Insert(report);
                }

                var roleIds = aInDto.RoleIds;
                foreach (var roleId in roleIds)
                {
                    var userToRole = new UsersToRoles();
                    userToRole.RoleId = roleId;
                    userToRole.UserId = resultObj.Id;

                    usersToRolesRepository.Insert(userToRole);
                }

                _baseRepository.GetDbContext().SaveChanges();
                //_dbContext.SaveChanges();
                return MappingTools.MapTo<Users, UserOutDto>(resultObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override UserOutDto Update(int aId, UserInDto aInDto)
        {
            var repoObj = _baseRepository.Select(aId);
            if (repoObj == null) throw new Exception("Object with id [" + aId + "] not found!");
            try
            {
                if (repoObj.FederationUsers.UserAuthorityId != aInDto.AuthorityId && !userContext.IsGlobalAdmin)
                {
                    throw new InvalidOperationException("Only Global_Admin can change administration");
                }
                if (repoObj.FederationUsers.Position != aInDto.Position && !userContext.IsGlobalAdmin && !userContext.IsAdmin)
                {
                    throw new InvalidOperationException("Only Global_Admin or Admin can change position");
                }

                repoObj = MappingTools.MapTo(aInDto, repoObj);
                repoObj.ModifiedOn = DateTime.Now;
                repoObj.ModifiedBy = this.userContext.UserName;

                UpdateFederationUser(aId, aInDto);


                var resultObj = _baseRepository.Update(repoObj);

                //delete old roles
                var usersToRoles = usersToRolesRepository//roles not reports
                    .SelectAll()
                    .Where(elem => elem.UserId == aId)
                    .ToList();
                usersToRoles.ForEach(elem => { usersToRolesRepository.Delete(elem.Id); });

                //delete old reports
                var usersToReports = usersToReportsRepository
                    .SelectAll()
                    .Where(elem => elem.UserId == aId)
                    .ToList();
                usersToReports.ForEach(elem => { usersToReportsRepository.Delete(elem.Id); });


                if (repoObj.FederationUsers.UserAuthorityId != aInDto.AuthorityId)
                {
                    //remove roleIds from previous administration
                    aInDto.RoleIds = aInDto.RoleIds.Except(usersToRoles.Select(x => x.RoleId)).ToArray();

                    //remove reportIds from previous administration
                    aInDto.ReportIds = aInDto.ReportIds.Except(usersToReports.Select(x => x.ReportId)).ToArray();
                }

                // insert new roles
                var roleIds = aInDto.RoleIds;
                foreach (var roleId in roleIds)
                {
                    var roleUser = new UsersToRoles();
                    roleUser.UserId = resultObj.Id;
                    roleUser.RoleId = roleId;
                    roleUser.CreatedOn = DateTime.Now;
                    roleUser.CreatedBy = this.userContext.UserName;

                    usersToRolesRepository.Insert(roleUser);
                }

                // insert new reports
                var reportIds = aInDto.ReportIds;
                foreach (var reportId in reportIds)
                {
                    var report = new UsersToReports();
                    report.ReportId = reportId;
                    report.UserId = resultObj.Id;
                    report.CreatedOn = DateTime.Now;
                    report.CreatedBy = this.userContext.UserName;

                    usersToReportsRepository.Insert(report);
                }

                _baseRepository.GetDbContext().SaveChanges();
                //_dbContext.SaveChanges();
                ClearFavouriteReports();

                return MappingTools.MapTo<Users, UserOutDto>(resultObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void UpdateFederationUser(int aId, UserInDto aInDto)
        {
            var currFederationUser = this.aFederationUsersRepository.Select(aId);
            currFederationUser.UserAuthorityId = aInDto.AuthorityId;
            currFederationUser.Position = aInDto.Position;
            this.aFederationUsersRepository.Update(currFederationUser);
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("authorityDisplayName", "FederationUsers/UserAuthority/DisplayName");
            dtoFieldsToEntityFields.Add("authorityId", "FederationUsers/UserAuthority/Id");
            dtoFieldsToEntityFields.Add("authority", "FederationUsers/UserAuthority/DisplayName");
            dtoFieldsToEntityFields.Add("position", "FederationUsers/Position");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }


    }
}