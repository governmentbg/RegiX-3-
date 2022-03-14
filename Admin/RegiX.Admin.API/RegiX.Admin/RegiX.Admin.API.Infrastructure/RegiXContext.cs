using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class RegiXContext
    {
        public const string SYSTEM = "SYSTEM";

        public virtual DbSet<StatisticsOutput> Statistics { get; set; }
        public virtual DbSet<ConsumerRequestOperationDb> ConsumerRequestOperationDb { get; set; }
        //public virtual DbSet<GetElementConsumersViewOutput> GetElementConsumers { get; set; }
        //public virtual DbSet<ApiServiceCallViewOutput> GetApiServiceCallView { get; set; }

        //public override int SaveChanges()
        //{
        //    //this.SimpleAudit();
        //    return base.SaveChanges();
        //}

        private void SetContext(DbConnection connection)
        {
            var command = connection.CreateCommand();

            command.CommandText = "SET_CONTEXT_INFO";
            command.CommandType = CommandType.StoredProcedure;

            var userParam = command.CreateParameter();
            userParam.DbType = DbType.String;
            userParam.Direction = ParameterDirection.Input;
            userParam.ParameterName = "P_USER_NAME";
            userParam.Value = UserContext.UserName ?? SYSTEM;
            command.Parameters.Add(userParam);

            command.ExecuteNonQuery();
        }

        private void OnConnectionOpened(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Open)
            {
                SetContext(this.Database.GetDbConnection());
            }
        }

        //protected void SimpleAudit()
        //{
        //    // Add audit info for create statements
        //    foreach (EntityEntry entry in this.ChangeTracker.Entries()
        //             .Where(t => t.State == EntityState.Added))
        //    {
        //        if (entry.Properties.Any(p => p.Metadata.Name == "CreatedBy") &&
        //            entry.Property("CreatedBy") != null)
        //        {
        //            entry.Property("CreatedBy").CurrentValue = UserContext.UserName ?? SYSTEM;
        //        }
        //        if (entry.Properties.Any(p => p.Metadata.Name == "CreatedOn"))
        //        {
        //            entry.Property("CreatedOn").CurrentValue = DateTime.Now;
        //        }
        //    }

        //    // Add audit info for update statements
        //    foreach (EntityEntry entry in this.ChangeTracker.Entries()
        //             .Where(t => t.State == EntityState.Modified))
        //    {
        //        if (entry.Properties.Any(p => p.Metadata.Name == "UpdatedBy") &&
        //            entry.Property("UpdatedBy") != null)
        //        {
        //            entry.Property("UpdatedBy").CurrentValue = UserContext.UserName ?? SYSTEM;
        //        }
        //        if (entry.Properties.Any(p => p.Metadata.Name == "UpdatedOn"))
        //        {
        //            entry.Property("UpdatedOn").CurrentValue = DateTime.Now;
        //        }
        //    }
        //}
    }
}
