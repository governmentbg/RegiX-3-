using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RegiX.Info.Infrastructure.Models;
using RegiX.Info.Repositories.Contracts;

namespace RegiX.Info.Repositories.Impl
{
    public class DatabaseOperationRepository : IDatabaseOperationRepository
    {
        protected readonly RegiXContext dbContext;

        public DatabaseOperationRepository(RegiXContext aDbContext)
        {
            this.dbContext = aDbContext;
        }
        public  List<Statistics> StatisticsProcedure(string timeFrame, bool showErrors)
        {
            return
                this.dbContext
                    .Statistics
                    .FromSqlRaw
                    (
                        "EXECUTE GetStatisticsXmlNew {0}, {1}, {2}",
                        DateTime.Now,
                        timeFrame,
                        showErrors
                    ).ToList();
        }

        public int GetMonthRecords(int year, int month)
        {
            return
                this.dbContext
                    .MonthlyStatistics
                    .FromSqlRaw
                    (
                        "EXECUTE GetMonthlyStatistics {0}, {1}",
                        year,
                        month
                    ).ToList().FirstOrDefault().Count;
        }

        public ConsumerRequestOperationDb GetHierarchyByOperationId(decimal operationId)
        {
            return
                dbContext
                    .ConsumerRequestOperationDb
                    .FromSqlRaw(
                        "EXECUTE GetHierarchyByOperationId {0}",
                        operationId
                    ).AsEnumerable().Single();
        }


    }
}