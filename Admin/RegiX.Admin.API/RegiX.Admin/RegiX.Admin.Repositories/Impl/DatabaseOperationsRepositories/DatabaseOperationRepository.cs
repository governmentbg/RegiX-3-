using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechnoLogica.RegiX.Admin.Infrastructure.Models;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;
using TechnoLogica.RegiX.Admin.Repositories.Contracts.DatabaseOperationsRepositoriesInterfaces;

namespace TechnoLogica.RegiX.Admin.Repositories.Impl.DatabaseOperationsRepositories
{
    public class DatabaseOperationRepository : IDatabaseOperationRepository
    {
        protected readonly RegiXContext _dbContext;

        //setting the dbContext
        public DatabaseOperationRepository(RegiXContext aDbContext)
        {
            _dbContext = aDbContext;
        }

        //function to call stored procedures
        public List<StatisticsOutput> CallProcedure(StatisticsInput input)
        {
            return
                _dbContext
                    .Statistics
                    .FromSqlRaw(
                        "EXECUTE GetStatistics {0}, {1} , {2} , {3} , {4} , {5}, {6}, {7}, {8}",
                        input.fromDate,
                        input.toDate,
                        input.consumerAdministrationId,
                        input.consumerId,
                        input.registerAdministrationId,
                        input.registerId,
                        input.adapterId,
                        input.adapterOperationId,
                        input.consumerDescription)
                    .ToList();
        }

        public ConsumerRequestOperationDb GetHierarchyByOperationId(decimal operationId)
        {
            return
                _dbContext
                    .ConsumerRequestOperationDb
                    .FromSqlRaw(
                        "EXECUTE GetHierarchyByOperationId {0}",
                        operationId
                    ).AsEnumerable().Single();
        }

        public List<GetElementConsumersViewOutput> GetElementConsumersProd(GetElementConsumersViewInput input)
        {
            //return
            //   _dbContext
            //       .GetElementConsumers
            //       .FromSqlRaw(
            //           "EXECUTE GetElementConsumersProd {0}, {1} , {2} , {3} , {4} , {5}, {6}",
            //           input.ConsumerAdministrationId,
            //           input.ConsumerId,
            //           input.CertificateId,
            //           input.AdministrationId,
            //           input.RegisterId,
            //           input.AdapterId,
            //           input.OperationId)
            //       .ToList();

            return new List<GetElementConsumersViewOutput>();
        }

        public List<AccessReportFilterView> GenerateView()
        {
            return _dbContext.Query<AccessReportFilterView>().ToList();

        }
    }
}