using Microsoft.EntityFrameworkCore;
using TechnoLogica.RegiX.Processors.AsyncAdapterConsole.DB.Entities;

namespace TechnoLogica.RegiX.Processors.AsyncAdapterConsole.DB
{
    public class RegiXAdapterConsoleContext : DbContext
    {
        public RegiXAdapterConsoleContext()
        {
        }

        public RegiXAdapterConsoleContext(DbContextOptions<RegiXAdapterConsoleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdapterOperations> AdapterOperations { get; set; }
        public virtual DbSet<OperationCalls> OperationCalls { get; set; }
        public virtual DbSet<ReturnedCalls> ReturnedCalls { get; set; }
        public virtual DbSet<OperationsPersistance> OperationsPersistance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(
                    "Server=regix2-sql.regix.tlogica.com;initial catalog=RegiXAdapterConsoleNew;persist security info=True;user id=;password=;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AdapterOperations>(entity =>
            {
                entity.ToTable("ADAPTER_OPERATIONS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contract)
                    .HasColumnName("CONTRACT")
                    .HasMaxLength(500);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(2000);

                entity.Property(e => e.MetadataRequestXml).HasColumnName("METADATA_REQUEST_XML");

                entity.Property(e => e.MetadataResponseXml).HasColumnName("METADATA_RESPONSE_XML");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<OperationCalls>(entity =>
            {
                entity.ToTable("OPERATION_CALLS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdapterOperationId).HasColumnName("ADAPTER_OPERATION_ID");

                entity.Property(e => e.ApiServiceCallId).HasColumnName("API_SERVICE_CALL_ID");

                entity.Property(e => e.AssignedTo).HasColumnName("ASSIGNED_TO");

                entity.Property(e => e.RequestXML)
                    .IsRequired()
                    .HasColumnName("REQUEST_XML");

                entity.Property(e => e.ResponseXML).HasColumnName("RESPONSE_XML");

                entity.Property(e => e.StartTime)
                    .HasColumnName("START_TIME")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.OperationCalls)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .HasConstraintName("FK_dbo.OPERATION_CALLS_dbo.ADAPTER_OPERATION_ID");
            });

            modelBuilder.Entity<ReturnedCalls>(entity =>
            {
                entity.ToTable("RETURNED_CALLS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdapterOperationId).HasColumnName("ADAPTER_OPERATION_ID");

                entity.Property(e => e.ApiServiceCallId).HasColumnName("API_SERVICE_CALL_ID");

                entity.Property(e => e.Request)
                    .IsRequired()
                    .HasColumnName("REQUEST");

                entity.Property(e => e.Response).HasColumnName("RESPONSE");

                entity.Property(e => e.ReturnedBy).HasColumnName("RETURNED_BY");

                entity.Property(e => e.StartTime)
                    .HasColumnName("START_TIME")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.ReturnedCalls)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .HasConstraintName("FK_dbo.RETURNED_CALLS_dbo.ADAPTER_OPERATION_ID");
            });

        modelBuilder.Entity<OperationsPersistance>(entity =>
            {
                entity.ToTable("OPERATIONS_PERSISTANCE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdapterOperationId).HasColumnName("ADAPTER_OPERATION_ID");

                entity.Property(e => e.VerificationCode).HasColumnName("VERIFICATION_CODE");

                entity.Property(e => e.ApiServiceCallId).HasColumnName("API_SERVICE_CALL_ID");
                
                entity.Property(e => e.RawRequst).HasColumnName("RAW_REQUEST");

                entity.Property(e => e.RawUnsignedResult).HasColumnName("RAW_UNSIGNED_RESULT");

                entity.Property(e => e.RawResult).HasColumnName("RAW_RESULT");

                entity.Property(e => e.CallbackUrl)
                    .HasColumnName("CALLBACK_URL");

                entity.Property(e => e.CallbackUrl)
                    .HasColumnName("CALLBACK_URL");

                entity.Property(e => e.Acknowledged)
                    .HasColumnName("ACKNOWLEDGED");

                entity.Property(e => e.RetryCount)
                    .HasColumnName("RETRY_COUNT");

                entity.Property(e => e.NextRetry)
                    .HasColumnName("NEXT_RETRY")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.OperationsPersistances)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .HasConstraintName("FK_dbo.OPERATIONS_PERSISTANCE_dbo.ADAPTER_OPERATION_ID");
            });
        }
    }
}