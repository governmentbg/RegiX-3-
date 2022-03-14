using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.Reports;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;
using TechnoLogica.RegiX.Client.Services.QueryValidators;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class ReportService : ABaseClearReportsService<ReportsInDto, ReportsOutDto, Reports>, IReportService
    {
        private readonly IRolesToReportsRepository rolesToReportRepository;
        private readonly IUsersToReportsRepository usersToReportsRepository;
        private readonly IUserContext userContext;

        public ReportService
        (
            IReportsRepository aBaseRepository,
            IUsersFavouriteReportRepository aFavouriteReportsRepository, 
            IReportsForUsersViewRepository aReportsForUserRepository,
            IDatabaseOperationsService aDatabaseOperationsService,
            IRolesToReportsRepository aRolesToReportRepository,
            IUsersToReportsRepository aUsersToReportsRepository,
            IUserContext aUserContext
        ) 
            : base(aBaseRepository, aFavouriteReportsRepository, aReportsForUserRepository, aDatabaseOperationsService)
        {
            rolesToReportRepository = aRolesToReportRepository;
            usersToReportsRepository = aUsersToReportsRepository;
            queryValidator = new ReportsQueryValidator();
            userContext = aUserContext;
        }


        //public ReportService(IReportsRepository aBaseRepository,
        //    IRolesToReportsRepository aRolesToReportRepository,
        //    IUsersToReportsRepository aUsersToReportsRepository,
        //    IUsersFavouriteReportRepository aFavouriteReportsRepository,
        //    IReportsForUsersViewRepository aReportsForUserRepository,
        //    IDatabaseOperationsService aDatabaseOperationsService,
        //    RegiXClientContext aDbContext)
        //    : base(aBaseRepository, aFavouriteReportsRepository, aReportsForUserRepository, aDatabaseOperationsService,
        //        aDbContext)
        //{
        //    rolesToReportRepository = aRolesToReportRepository;
        //    usersToReportsRepository = aUsersToReportsRepository;

        //}

        public override ReportsOutDto Insert(ReportsInDto aInDto)
        {
            try
            {
                var mappedObj = MappingTools.MapTo<ReportsInDto, Reports>(aInDto);

                var resultObj = _baseRepository.Insert(mappedObj);
                var roleIds = aInDto.RoleIds;
                foreach (var roleId in roleIds)
                {
                    var report = new RolesToReports();
                    report.Report = resultObj;
                    report.RoleId = roleId;

                    rolesToReportRepository.Insert(report);
                }

                var userIds = aInDto.UserIds;
                foreach (var userId in userIds)
                {
                    var userToRole = new UsersToReports();
                    userToRole.UserId = userId;
                    userToRole.Report = resultObj;

                    usersToReportsRepository.Insert(userToRole);
                }

                _baseRepository.GetDbContext().SaveChanges();
                return MappingTools.MapTo<Reports, ReportsOutDto>(resultObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override ReportsOutDto Update(int aId, ReportsInDto aInDto)
        {
            var repoObj = _baseRepository.Select(aId);
            if (repoObj == null) throw new Exception("Object with id [" + aId + "] not found!");
            try
            {
                repoObj = MappingTools.MapTo(aInDto, repoObj);

                repoObj.ModifiedOn = DateTime.Now;
                repoObj.ModifiedBy = this.userContext.UserName;

                var resultObj = _baseRepository.Update(repoObj);

                //get all users
                var usersToReports = usersToReportsRepository
                    .SelectAll()
                    .Where(elem => elem.ReportId == aId)
                    .ToList();

                //remove only those that are not present in aInDto.UserIds
                var usersToReportsToDelete = usersToReports
                    .Where(x => !aInDto.UserIds.Contains(x.UserId))
                    .ToList();
                usersToReportsToDelete.ForEach(elem => { usersToReportsRepository.Delete(elem.Id); });

                usersToReports = usersToReports
                    .Where(x => aInDto.UserIds.Contains(x.UserId))
                    .ToList();

                //get all reports
                var rolesToReport = rolesToReportRepository
                    .SelectAll()
                    .Where(elem => elem.ReportId == aId)
                    .ToList();

                //remove only those that are not present in aInDto.UserIds
                var rolesToReportToDelete = rolesToReport
                    .Where(x => !aInDto.RoleIds.Contains(x.RoleId))
                    .ToList();
                rolesToReportToDelete.ForEach(elem => { rolesToReportRepository.Delete(elem.Id); });

                rolesToReport = rolesToReport
                    .Where(x => aInDto.RoleIds.Contains(x.RoleId))
                    .ToList();

                //Add only new elements to DB 
                var usersToReportsIdsToAdd = aInDto.UserIds
                    .Where(x => !usersToReports.Select(y => y.UserId).Contains(x)).ToList();

                foreach (var userId in usersToReportsIdsToAdd)
                {
                    var roleUser = new UsersToReports();
                    roleUser.UserId = userId;
                    roleUser.ReportId = resultObj.Id;
                    roleUser.CreatedOn = DateTime.Now;
                    repoObj.CreatedBy = this.userContext.UserName;
                    usersToReportsRepository.Insert(roleUser);
                }

                // insert new reports
                //Add only new elements to DB 
                var rolesToReportIdsToAdd = aInDto.RoleIds
                    .Where(x => !rolesToReport.Select(y => y.RoleId).Contains(x)).ToList();
                foreach (var roleId in rolesToReportIdsToAdd)
                {
                    var report = new RolesToReports();
                    report.ReportId = resultObj.Id;
                    report.RoleId = roleId;
                    report.CreatedOn = DateTime.Now;
                    report.CreatedBy = this.userContext.UserName;

                    rolesToReportRepository.Insert(report);
                }

                _baseRepository.GetDbContext().SaveChanges();
                ClearFavouriteReports();

                return MappingTools.MapTo<Reports, ReportsOutDto>(resultObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
            dtoFieldsToEntityFields.Add("adapterOperation.id", "AdapterOperation/Id");
            dtoFieldsToEntityFields.Add("adapterOperation.displayName", "AdapterOperation/DisplayOperationName");
            dtoFieldsToEntityFields.Add("authority.id", "Authority/Id");
            dtoFieldsToEntityFields.Add("authority.displayName", "Authority/Name");
            dtoFieldsToEntityFields.Add("register.id", "AdapterOperation/Register/Id");
            dtoFieldsToEntityFields.Add("register.displayName", "AdapterOperation/Register/Name");
            dtoFieldsToEntityFields.Add("registerAuthority.id", "AdapterOperation/Register/Authority/Id");
            dtoFieldsToEntityFields.Add("registerAuthority.displayName", "AdapterOperation/Register/Authority/Name");
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            return false;
        }
    }
}