using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData.Query.Validators;
using TechnoLogica.API.Services;
using TechnoLogica.RegiX.Client.API.DataContracts.DTO.UserToReport;
using TechnoLogica.RegiX.Client.Infrastructure.Models;
using TechnoLogica.RegiX.Client.Repositories;
using TechnoLogica.RegiX.Client.Repositories.Contracts;
using TechnoLogica.RegiX.Client.Services.Contracts;

namespace TechnoLogica.RegiX.Client.Services.Services
{
    public class UsersFavouriteReportService : ABaseService<UsersFavouriteReportInDto,
        UsersFavouriteReportOutDto, UsersFavouriteReports, int,RegiXClientContext>, IUserFavouriteReportService
    {
        private readonly IReportsForUsersViewRepository reportsForUsersViewRepository;
        private IUserContext UserContext { get; set; }

        public UsersFavouriteReportService(IUsersFavouriteReportRepository aBaseRepository,
            IReportsForUsersViewRepository aReportForUsersViewRepository,
            IUserContext userContext)
            : base(aBaseRepository)
        {
            reportsForUsersViewRepository = aReportForUsersViewRepository;
            UserContext = userContext;
        }

        public override UsersFavouriteReportOutDto Insert(UsersFavouriteReportInDto aInDto)
        {
            if (UserContext?.UserId.HasValue == true)
            {
                var userId = UserContext.UserId.Value;

                //delete old favourites
                var usersToReports = _baseRepository
                    .SelectAll()
                    .Where(elem => elem.UserId == userId)
                    .ToList();
                usersToReports.ForEach(elem => { _baseRepository.Delete(elem.Id); });

                var reportIds = aInDto.ReportIds;
                foreach (var reportId in reportIds)
                {
                    var report = new UsersFavouriteReports();
                    report.ReportId = reportId;
                    report.UserId = userId;

                    var found = reportsForUsersViewRepository
                        .SelectAll()
                        .Where(elem => elem.UserId == userId && elem.ReportId == reportId)
                        .ToList();

                    if (found.Count > 0)
                        _baseRepository.Insert(report);
                    else
                        throw new Exception("You are trying to add report to which you have no access!");
                }

                _baseRepository.GetDbContext().SaveChanges();
                //_dbContext.SaveChanges();
                return null;
            }
            else
            {
                return null;
            }
        }

        protected override void PopulateDtoToEntityFieldsMapping()
        {
        }

        protected override bool IsChildRecord(int aId, List<string> aParentsList)
        {
            throw new NotImplementedException();
        }

        public void ChangeReportFavouriteStatus(int reportId, bool favourite)
        {
            if (UserContext?.UserId.HasValue == true)
            {
                int userId = UserContext.UserId.Value;
                if (favourite)
                {
                    this._baseRepository.Insert(
                        new UsersFavouriteReports()
                        {
                            UserId = userId,
                            ReportId = reportId
                        });
                    this._baseRepository.GetDbContext().SaveChanges();
                }
                else
                {
                    var favouriteRecord = 
                        this._baseRepository
                        .SelectAll()
                        .Where(uf => uf.ReportId == reportId && uf.UserId == userId)
                        .SingleOrDefault();
                    if (favouriteRecord != null)
                    {
                        this._baseRepository.Delete(favouriteRecord.Id);
                        this._baseRepository.GetDbContext().SaveChanges();
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("UserId");
            }
        }
    }
}