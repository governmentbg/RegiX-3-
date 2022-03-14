using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationService;
using TechnoLogica.RegiX.Admin.Infrastructure.Models.DatabaseOperationsModels;

namespace TechnoLogica.RegiX.Admin.Infrastructure.Models
{
    public partial class RegiXContext : DbContext
    {
        protected IUserContext UserContext { get; private set; }

        public RegiXContext()
        {
        }

        public RegiXContext(DbContextOptions<RegiXContext> options, IUserContext context)
            : base(options)
        {
            UserContext = context;
            this.Database.GetDbConnection().StateChange += OnConnectionOpened;
        }

        public virtual DbSet<AdapterHealthFunctions> AdapterHealthFunctions { get; set; }
        public virtual DbSet<AdapterHealthResults> AdapterHealthResults { get; set; }
        public virtual DbSet<AdapterOperationLog> AdapterOperationLog { get; set; }
        public virtual DbSet<AdapterOperations> AdapterOperations { get; set; }
        public virtual DbSet<AdapterPingResults> AdapterPingResults { get; set; }
        public virtual DbSet<AdministrationTypes> AdministrationTypes { get; set; }
        public virtual DbSet<Administrations> Administrations { get; set; }
        public virtual DbSet<ApiServiceAdapterOperations> ApiServiceAdapterOperations { get; set; }
        public virtual DbSet<ApiServiceCalls> ApiServiceCalls { get; set; }
        public virtual DbSet<ApiServiceConsumers> ApiServiceConsumers { get; set; }
        public virtual DbSet<ApiServiceOperationLog> ApiServiceOperationLog { get; set; }
        public virtual DbSet<ApiServiceOperations> ApiServiceOperations { get; set; }
        public virtual DbSet<ApiServices> ApiServices { get; set; }
        public virtual DbSet<AuditExceptions> AuditExceptions { get; set; }
        public virtual DbSet<AuditTables> AuditTables { get; set; }
        public virtual DbSet<AuditUserActions> AuditUserActions { get; set; }
        public virtual DbSet<AuditValues> AuditValues { get; set; }
        public virtual DbSet<CertificateAccessComments> CertificateAccessComments { get; set; }
        public virtual DbSet<CertificateConsumerRole> CertificateConsumerRole { get; set; }
        public virtual DbSet<CertificateElementAccess> CertificateElementAccess { get; set; }
        public virtual DbSet<CertificateOperationAccess> CertificateOperationAccess { get; set; }
        public virtual DbSet<CertificateOperationAccessExtended> CertificateOperationAccessExtended { get; set; }
        public virtual DbSet<ConsumerAccessRequests> ConsumerAccessRequests { get; set; }
        public virtual DbSet<ConsumerCertificateEids> ConsumerCertificateEids { get; set; }
        public virtual DbSet<ConsumerCertificates> ConsumerCertificates { get; set; }
        public virtual DbSet<ConsumerCertificatesReports> ConsumerCertificatesReports { get; set; }
        public virtual DbSet<ConsumerProfileStatus> ConsumerProfileStatus { get; set; }
        public virtual DbSet<ConsumerProfileUsers> ConsumerProfileUsers { get; set; }
        public virtual DbSet<ConsumerProfiles> ConsumerProfiles { get; set; }
        public virtual DbSet<ConsumerRequestElements> ConsumerRequestElements { get; set; }
        public virtual DbSet<ConsumerRoleElementAccess> ConsumerRoleElementAccess { get; set; }
        public virtual DbSet<ConsumerRoleOperationAccess> ConsumerRoleOperationAccess { get; set; }
        public virtual DbSet<ConsumerRoles> ConsumerRoles { get; set; }
        public virtual DbSet<ConsumerSystemCertificates> ConsumerSystemCertificates { get; set; }
        public virtual DbSet<ConsumerSystems> ConsumerSystems { get; set; }
        public virtual DbSet<CustomParameters> CustomParameters { get; set; }
        public virtual DbSet<HealthServiceLog> HealthServiceLog { get; set; }
        public virtual DbSet<HealthServiceOffline> HealthServiceOffline { get; set; }
        public virtual DbSet<HealthServicePing> HealthServicePing { get; set; }
        public virtual DbSet<OperationParameters> OperationParameters { get; set; }
        public virtual DbSet<OperationsErrorLog> OperationsErrorLog { get; set; }
        public virtual DbSet<ParameterTypes> ParameterTypes { get; set; }
        public virtual DbSet<ParametersValuesLog> ParametersValuesLog { get; set; }
        public virtual DbSet<RegisterAdapters> RegisterAdapters { get; set; }
        public virtual DbSet<RegisterObjectElements> RegisterObjectElements { get; set; }
        public virtual DbSet<RegisterObjects> RegisterObjects { get; set; }
        public virtual DbSet<RegisterObjectsLog> RegisterObjectsLog { get; set; }
        public virtual DbSet<Registers> Registers { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersEAuth> UsersEauth { get; set; }

        public virtual DbSet<ApprovedRequestElements> ApprovedRequestElements { get; set; }
        public virtual DbSet<ConsumerAccessRequestsStatus> ConsumerAccessRequestsStatus { get; set; }
        public virtual DbSet<ConsumerRequestStatus> ConsumerRequestStatus { get; set; }
        public virtual DbSet<ConsumerRequests> ConsumerRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApprovedRequestElements>(entity =>
            {
                entity.ToTable("APPROVED_REQUEST_ELEMENTS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ConsumerAccessRequestId)
                    .HasColumnName("CONSUMER_ACCESS_REQUEST_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на сертификат");

                entity.Property(e => e.RegisterObjectElementId)
                    .HasColumnName("REGISTER_OBJECT_ELEMENT_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на елемент на обект");

                entity.HasOne(d => d.ConsumerAccessRequest)
                    .WithMany(p => p.ApprovedRequestElements)
                    .HasForeignKey(d => d.ConsumerAccessRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPROVED_REQUEST_ELEMENTS_REGISTER_OBJECT_ELEMENTS");

                entity.HasOne(d => d.RegisterObjectElement)
                    .WithMany(p => p.ApprovedRequestElements)
                    .HasForeignKey(d => d.RegisterObjectElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPROVED_REQUEST_ELEMENTS_CONSUMER_ACCESS_REQUESTS");
            });

            modelBuilder.Entity<ConsumerAccessRequestsStatus>(entity =>
            {
                entity.ToTable("CONSUMER_ACCESS_REQUESTS_STATUS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Comment).HasColumnName("COMMENT");

                entity.Property(e => e.ConsumerAccessRequestId)
                    .HasColumnName("CONSUMER_ACCESS_REQUEST_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewStatus).HasColumnName("NEW_STATUS");

                entity.Property(e => e.OldStatus).HasColumnName("OLD_STATUS");

                entity.HasOne(d => d.ConsumerAccessRequest)
                    .WithMany(p => p.ConsumerAccessRequestsStatus)
                    .HasForeignKey(d => d.ConsumerAccessRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_ACCESS_REQUESTS_STATUS_CONSUMER_ACCESS_REQUESTS");
            });

            modelBuilder.Entity<AdapterHealthFunctions>(entity =>
            {
                entity.HasKey(e => e.AdapterHealthFunctionId)
                    .HasName("XPKADAPTER_HEALTH_FUNCTION");

                entity.ToTable("ADAPTER_HEALTH_FUNCTIONS");

                entity.HasComment("Функции за състояние на адаптери");

                entity.Property(e => e.AdapterHealthFunctionId)
                    .HasColumnName("ADAPTER_HEALTH_FUNCTION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на функция")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Код");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.RegisterAdapterId)
                    .HasColumnName("REGISTER_ADAPTER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на адаптер на регистър");

                entity.HasOne(d => d.RegisterAdapter)
                    .WithMany(p => p.AdapterHealthFunctions)
                    .HasForeignKey(d => d.RegisterAdapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HEALTH_FUNCTION_ADAPTER");
            });

            modelBuilder.Entity<AdapterHealthResults>(entity =>
            {
                entity.HasKey(e => e.AdapterHealthResultId)
                    .HasName("XPKADAPTER_HEALTH_RESULT");

                entity.ToTable("ADAPTER_HEALTH_RESULTS");

                entity.HasComment("Резултати на функции за състояние на адаптери");

                entity.HasIndex(e => e.RegisterAdapterId)
                    .HasName("IX_ADAPTER_HEALTH_RESULTS");

                entity.HasIndex(e => new { e.HealthResult, e.RegisterAdapterId, e.AdapterHealthFunctionId, e.ExecuteTime })
                    .HasName("IX_ADAPTER_HEALTH_RESULTS_FUNCTION");

                entity.HasIndex(e => new { e.RegisterAdapterId, e.AdapterHealthFunctionId, e.HealthResult, e.ExecuteTime })
                    .HasName("IX_ADAPTER_HEALTH_RESULTS_EXECUTE");

                entity.Property(e => e.AdapterHealthResultId)
                    .HasColumnName("ADAPTER_HEALTH_RESULT_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на резултат")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdapterHealthFunctionId)
                    .HasColumnName("ADAPTER_HEALTH_FUNCTION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на функция");

                entity.Property(e => e.AppName)
                    .HasColumnName("APP_NAME")
                    .HasMaxLength(128)
                    ;//.HasDefaultValueSql("(app_name())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.ExecuteTime)
                    .HasColumnName("EXECUTE_TIME")
                    .HasColumnType("datetime")
                    .HasComment("Време на изпълнение");

                entity.Property(e => e.HealthError)
                    .HasColumnName("HEALTH_ERROR")
                    .IsUnicode(false)
                    .HasComment("Грешка при изпълнение");

                entity.Property(e => e.HealthResult)
                    .HasColumnName("HEALTH_RESULT")
                    .HasColumnType("varchar(max)")
                    .HasComment("Резултат от изпълнение");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(128)
                    ;//.HasDefaultValueSql("(CONVERT([nvarchar],connectionproperty('client_net_address')))");

                entity.Property(e => e.RegisterAdapterId)
                    .HasColumnName("REGISTER_ADAPTER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на адаптер на регистър");

                entity.HasOne(d => d.AdapterHealthFunction)
                    .WithMany(p => p.AdapterHealthResults)
                    .HasForeignKey(d => d.AdapterHealthFunctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HEALTH_RESULT_FUNCTION");

                entity.HasOne(d => d.RegisterAdapter)
                    .WithMany(p => p.AdapterHealthResults)
                    .HasForeignKey(d => d.RegisterAdapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HEALTH_RESULT_ADAPTER");
            });

            modelBuilder.Entity<AdapterOperationLog>(entity =>
            {
                entity.ToTable("ADAPTER_OPERATION_LOG");

                entity.HasComment("Лог на операциите на адаптери");

                entity.HasIndex(e => e.AdapterOperationId)
                    .HasName("XIF2API_SERVICE_CALL_ADAPTER_O");

                entity.HasIndex(e => e.ApiServiceCallId)
                    .HasName("XIF1API_SERVICE_CALL_ADAPTER_O");

                entity.Property(e => e.AdapterOperationLogId)
                    .HasColumnName("ADAPTER_OPERATION_LOG_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на лог на операция на адаптер")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdapterOperationId)
                    .HasColumnName("ADAPTER_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на адаптер");

                entity.Property(e => e.ApiServiceCallId)
                    .HasColumnName("API_SERVICE_CALL_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на извикаване на услуга");

                entity.Property(e => e.EndTime)
                    .HasColumnName("END_TIME")
                    .HasColumnType("datetime")
                    .HasComment("Време на приключване");

                entity.Property(e => e.StartTime)
                    .HasColumnName("START_TIME")
                    .HasColumnType("datetime")
                    .HasComment("Време на стартиране");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.AdapterOperationLog)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOG_ADAPTER_OPERATION");
            });

            modelBuilder.Entity<AdapterOperations>(entity =>
            {
                entity.HasKey(e => e.AdapterOperationId);

                entity.ToTable("ADAPTER_OPERATIONS");

                entity.HasComment("Методи на адаптери");

                entity.HasIndex(e => e.RegisterAdapterId)
                    .HasName("IFK1_ADAPTER_OPERATIONS");

                entity.HasIndex(e => e.RegisterObjectId)
                    .HasName("IFK2_ADAPTER_OPERATIONS");

                entity.Property(e => e.AdapterOperationId)
                    .HasColumnName("ADAPTER_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на адаптер")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.RegisterAdapterId)
                    .HasColumnName("REGISTER_ADAPTER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на адаптер на регистър");

                entity.Property(e => e.RegisterObjectId)
                    .HasColumnName("REGISTER_OBJECT_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на обект на регистър");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.RegisterAdapter)
                    .WithMany(p => p.AdapterOperations)
                    .HasForeignKey(d => d.RegisterAdapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATION_ADAPTER");

                entity.HasOne(d => d.RegisterObject)
                    .WithMany(p => p.AdapterOperations)
                    .HasForeignKey(d => d.RegisterObjectId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ADAPTER_OBJECT");
            });

            modelBuilder.Entity<AdapterPingResults>(entity =>
            {
                entity.HasKey(e => e.AdapterPingResultId)
                    .HasName("XPKADAPTER_PING_RESULT");

                entity.ToTable("ADAPTER_PING_RESULTS");

                entity.HasComment("Резултати от ping на адаптер");

                entity.HasIndex(e => e.RegisterAdapterId)
                    .HasName("IX_ADAPTER_PING_RESULTS");

                entity.HasIndex(e => new { e.RegisterAdapterId, e.Timeout, e.ExecuteTime })
                    .HasName("IX_ADAPTER_PING_RESULTS_EXECUTION");

                entity.HasIndex(e => new { e.Timeout, e.RegisterAdapterId, e.ExecuteTime })
                    .HasName("IX_ADAPTER_PING_RESULTS_REGISTER_ADAPTER_ID");

                entity.Property(e => e.AdapterPingResultId)
                    .HasColumnName("ADAPTER_PING_RESULT_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на Ping")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AppName)
                    .HasColumnName("APP_NAME")
                    .HasMaxLength(128)
                    ;//.HasDefaultValueSql("(app_name())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.ExecuteTime)
                    .HasColumnName("EXECUTE_TIME")
                    .HasColumnType("datetime")
                    .HasComment("Време на изпълнение");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(128)
                    ;//.HasDefaultValueSql("(CONVERT([nvarchar],connectionproperty('client_net_address')))");

                entity.Property(e => e.RegisterAdapterId)
                    .HasColumnName("REGISTER_ADAPTER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на адаптер на регистър");

                entity.Property(e => e.ReplyTime)
                    .HasColumnName("REPLY_TIME")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Време за изпълнение");

                entity.Property(e => e.Timeout)
                    .HasColumnName("TIMEOUT")
                    .HasColumnType("numeric(1, 0)")
                    .HasComment("Timeout");

                entity.HasOne(d => d.RegisterAdapter)
                    .WithMany(p => p.AdapterPingResults)
                    .HasForeignKey(d => d.RegisterAdapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PING_RESULT_ADAPTER");
            });

            modelBuilder.Entity<AdministrationTypes>(entity =>
            {
                entity.HasKey(e => e.AdministrationTypeId)
                    .HasName("PK_ADMINISTRATION_TYPE");

                entity.ToTable("ADMINISTRATION_TYPES");

                entity.HasComment("Типове администрации");

                entity.Property(e => e.AdministrationTypeId)
                    .HasColumnName("ADMINISTRATION_TYPE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на тип администрация")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.PubliclyVisible)
                    .HasColumnName("PUBLICLY_VISIBLE")
                    .IsRequired()
                    .HasComment("Публично видим");
            });

            modelBuilder.Entity<Administrations>(entity =>
            {
                entity.HasKey(e => e.AdministrationId)
                    .HasName("PK_ADMINISTRATION");

                entity.ToTable("ADMINISTRATIONS");

                entity.HasComment("Администрации");

                entity.Property(e => e.AdministrationId)
                    .HasColumnName("ADMINISTRATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на администрация")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Acronym)
                    .HasColumnName("ACRONYM")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdministrationTypeId)
                    .HasColumnName("ADMINISTRATION_TYPE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("Тип администрация");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                     ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                     ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Depth).HasColumnName("DEPTH");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.Oid)
                    .HasColumnName("OID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ParentAuthorityId)
                    .HasColumnName("PARENT_AUTHORITY_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.PathToRoot)
                    .HasColumnName("PATH_TO_ROOT")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.PathToRootNames)
                    .HasColumnName("PATH_TO_ROOT_NAMES")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.PubliclyVisible)
                    .HasColumnName("PUBLICLY_VISIBLE")
                    
                    .HasComment("Публично видими")
                    ;//.HasDefaultValueSql("((1))")

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.AdministrationType)
                    .WithMany(p => p.Administrations)
                    .HasForeignKey(d => d.AdministrationTypeId)
                    .HasConstraintName("FK_ADMINISTRATION_ADMINISTRATION_TYPE");

                entity.HasOne(d => d.ParentAuthority)
                    .WithMany(p => p.InverseParentAuthority)
                    .HasForeignKey(d => d.ParentAuthorityId)
                    .HasConstraintName("FK_ADMINISTRATIONS_ADMINISTRATIONS");
            });

            modelBuilder.Entity<ApiServiceAdapterOperations>(entity =>
            {
                entity.ToTable("API_SERVICE_ADAPTER_OPERATIONS");

                entity.HasComment("Операции на адаптери за API услуга");

                entity.HasIndex(e => e.AdapterOperationId)
                    .HasName("XIF1ADAPTER_OPERATION_API_SERV");

                entity.HasIndex(e => e.ApiServiceOperationId)
                    .HasName("XIF2ADAPTER_OPERATION_API_SERV");

                entity.HasIndex(e => new { e.AdapterOperationId, e.ApiServiceOperationId })
                    .HasName("UNI_ser_ada_operationd")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdapterOperationId)
                    .HasColumnName("ADAPTER_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на адаптер");

                entity.Property(e => e.ApiServiceOperationId)
                    .HasColumnName("API_SERVICE_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на услуга");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.ApiServiceAdapterOperations)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADAPTER_OPERATION_SERVICE");

                entity.HasOne(d => d.ApiServiceOperation)
                    .WithMany(p => p.ApiServiceAdapterOperations)
                    .HasForeignKey(d => d.ApiServiceOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICE_ADAPTER_OPERATION");
            });

            modelBuilder.Entity<ApiServiceCalls>(entity =>
            {
                entity.HasKey(e => e.ApiServiceCallId)
                    .HasName("XPKAPI_SERVICE_CALLS");

                entity.ToTable("API_SERVICE_CALLS");

                entity.HasComment("Стартирани операции на API услуги");

                entity.HasIndex(e => e.ApiServiceCallId)
                    .HasName("PK_API_SERVICE_CALLS_");

                entity.HasIndex(e => new { e.ApiServiceOperationId, e.ConsumerCertificateId, e.StartTime })
                    .HasName("START_DATE_INDEX");

                entity.HasIndex(e => new { e.ApiServiceOperationId, e.ConsumerCertificateId, e.StartTime, e.HasError })
                    .HasName("START_DATE_ERR_INDEX");

                entity.Property(e => e.ApiServiceCallId)
                    .HasColumnName("API_SERVICE_CALL_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на извикаване на услуга")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ApiServiceOperationId)
                    .HasColumnName("API_SERVICE_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на услуга");

                entity.Property(e => e.AppName)
                    .HasColumnName("APP_NAME")
                    .HasMaxLength(128)
                    ;//.HasDefaultValueSql("(app_name())");

                entity.Property(e => e.CallContext)
                    .HasColumnName("CALL_CONTEXT")
                    .IsUnicode(false)
                    .HasComment("Допълнително поле за контекст в свободен текст ");

                entity.Property(e => e.ClientIpAddress)
                    .HasColumnName("CLIENT_IP_ADDRESS")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("IP адрес на клиента");

                entity.Property(e => e.ConsumerCertificateId)
                    .HasColumnName("CONSUMER_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на сертификат");

                entity.Property(e => e.ContextAdministrationName)
                    .HasColumnName("CONTEXT_ADMINISTRATION_NAME")
                    .IsUnicode(false)
                    .HasComment("Име на администрация");

                entity.Property(e => e.ContextAdministrationOid)
                    .HasColumnName("CONTEXT_ADMINISTRATION_OID")
                    .IsUnicode(false)
                    .HasComment("Идентификационен код на администрация (oID от eAuth)");

                entity.Property(e => e.ContextEmployeeAditionalId)
                    .HasColumnName("CONTEXT_EMPLOYEE_ADITIONAL_ID")
                    .IsUnicode(false)
                    .HasComment("Опционален допълнителен идентификатор на служител от администрация – например номера на служебната карта, или нещо такова");

                entity.Property(e => e.ContextEmployeeIdentifier)
                    .HasColumnName("CONTEXT_EMPLOYEE_IDENTIFIER")
                    .IsUnicode(false)
                    .HasComment("Идентификатор на служител – например EMAIL адрес, с която служителя влиза в директорията на съответната администрация (или с който фигурира в ЕИСУЧРДА). Идеята е този идентификатор да е реално проверен от клиента за Regix. Например в случая с нашия web client от ADFS си извлича username Който съвпада в случаите досега с email адреса на потребителя.");

                entity.Property(e => e.ContextEmployeeNames)
                    .HasColumnName("CONTEXT_EMPLOYEE_NAMES")
                    .IsUnicode(false)
                    .HasComment("Име на служител");

                entity.Property(e => e.ContextEmployeePosition)
                    .HasColumnName("CONTEXT_EMPLOYEE_POSITION")
                    .IsUnicode(false)
                    .HasComment("Длъжност или позиция на служителя в администрацията");

                entity.Property(e => e.ContextLawReason)
                    .HasColumnName("CONTEXT_LAW_REASON")
                    .IsUnicode(false)
                    .HasComment("Контекст на правното основание – например името на справката (със съответните членове)");

                entity.Property(e => e.ContextResponsibleNames)
                    .HasColumnName("CONTEXT_RESPONSIBLE_NAMES")
                    .IsUnicode(false)
                    .HasComment("Опционален идентификатор на човека отговорен за справката. Тук може да се слага ЕГН например, или нещо друго");

                entity.Property(e => e.ContextSerivceUri)
                    .HasColumnName("CONTEXT_SERIVCE_URI")
                    .IsUnicode(false)
                    .HasComment("Опционален идентификатор на инстанцията на административната услуга в организацията (например номер на преписка или нещо подобно)");

                entity.Property(e => e.ContextServiceType)
                    .HasColumnName("CONTEXT_SERVICE_TYPE")
                    .IsUnicode(false)
                    .HasComment("Тип на услугата, за която се ползва – за административна услуга, за проверовъчна дейност");

                entity.Property(e => e.EidToken)
                    .HasColumnName("EID_TOKEN")
                    .IsUnicode(false)
                    .HasComment("Електронна идентификация");

                entity.Property(e => e.EndTime)
                    .HasColumnName("END_TIME")
                    .HasColumnType("datetime")
                    .HasComment("Време на приключване");

                entity.Property(e => e.ErrorContent)
                    .HasColumnName("ERROR_CONTENT")
                    .IsUnicode(false)
                    .HasComment("Съдържание на грешка");

                entity.Property(e => e.HasError)
                    .HasColumnName("HAS_ERROR")
                    .HasComment("Изпълнението съдържа грешка");

                entity.Property(e => e.InstanceId)
                    .HasColumnName("INSTANCE_ID")
                    .HasComment("Workflow instance");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(128)
                    ;//.HasDefaultValueSql("(CONVERT([nvarchar],connectionproperty('client_net_address')))");

                entity.Property(e => e.OidToken)
                    .HasColumnName("OID_TOKEN")
                    .IsUnicode(false);

                entity.Property(e => e.ResultContent)
                    .HasColumnName("RESULT_CONTENT")
                    .IsUnicode(false)
                    .HasComment("Резултат от изпълнение");

                entity.Property(e => e.ResultReady)
                    .HasColumnName("RESULT_READY")
                    .HasComment("Резултатът е готов");

                entity.Property(e => e.ResultReturned)
                    .HasColumnName("RESULT_RETURNED")
                    .HasComment("Резултатът е върнат");

                entity.Property(e => e.StartTime)
                    .HasColumnName("START_TIME")
                    .HasColumnType("datetime")
                    .HasComment("Време на стартиране");

                entity.HasOne(d => d.ApiServiceOperation)
                    .WithMany(p => p.ApiServiceCalls)
                    .HasForeignKey(d => d.ApiServiceOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CALL_SERVICE_OPERATION");

                entity.HasOne(d => d.ConsumerCertificate)
                    .WithMany(p => p.ApiServiceCalls)
                    .HasForeignKey(d => d.ConsumerCertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CALL_CERTIFICATE");
            });

            modelBuilder.Entity<ApiServiceConsumers>(entity =>
            {
                entity.HasKey(e => e.ApiServiceConsumerId);

                entity.ToTable("API_SERVICE_CONSUMERS");

                entity.HasComment("Ползватели на API за регистри");

                entity.HasIndex(e => e.Oid)
                    .HasName("UK_API_SERVICE_CONSUMERS")
                    .IsUnique();

                entity.Property(e => e.ApiServiceConsumerId)
                    .HasColumnName("API_SERVICE_CONSUMER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на ползвател")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdministrationId)
                    .HasColumnName("ADMINISTRATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("Администрация по подразбиране(информативно поле, не би трябвало да се ползва за ограничения, а за помощ в потребителския интерфейс)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                     ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                     ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.Oid)
                    .HasColumnName("OID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                     ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                     ;//.HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.Administration)
                    .WithMany(p => p.ApiServiceConsumers)
                    .HasForeignKey(d => d.AdministrationId)
                    .HasConstraintName("FK_API_SERVICE_CONSUMERS_ADMINISTRATIONS");
            });

            modelBuilder.Entity<ApiServiceOperationLog>(entity =>
            {
                entity.ToTable("API_SERVICE_OPERATION_LOG");

                entity.HasComment("Лог на операциите за API услуги");

                entity.HasIndex(e => e.ApiServiceOperationId)
                    .HasName("XIF2API_SERVICE_CALL_API_SERVI");

                entity.HasIndex(e => e.ServiceCallId)
                    .HasName("XIF1API_SERVICE_CALL_API_SERVI");

                entity.Property(e => e.ApiServiceOperationLogId)
                    .HasColumnName("API_SERVICE_OPERATION_LOG_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на лог на опеацията")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ApiServiceOperationId)
                    .HasColumnName("API_SERVICE_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на услуга");

                entity.Property(e => e.EndTime)
                    .HasColumnName("END_TIME")
                    .HasColumnType("datetime")
                    .HasComment("Време на приключване");

                entity.Property(e => e.ServiceCallId)
                    .HasColumnName("SERVICE_CALL_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на извикаване на услуга");

                entity.Property(e => e.StartTime)
                    .HasColumnName("START_TIME")
                    .HasColumnType("datetime")
                    .HasComment("Време на стартиране");

                entity.HasOne(d => d.ApiServiceOperation)
                    .WithMany(p => p.ApiServiceOperationLog)
                    .HasForeignKey(d => d.ApiServiceOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOG_SERVICE_OPERATION");
            });

            modelBuilder.Entity<ApiServiceOperations>(entity =>
            {
                entity.HasKey(e => e.ApiServiceOperationId);

                entity.ToTable("API_SERVICE_OPERATIONS");

                entity.HasComment("Методи на API услуги");

                entity.HasIndex(e => e.ApiServiceId)
                    .HasName("IFK1_API_SERVICE_OPERATIONS");

                entity.Property(e => e.ApiServiceOperationId)
                    .HasColumnName("API_SERVICE_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на услуга")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ApiServiceId)
                    .HasColumnName("API_SERVICE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на API услуга");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                     ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                     ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.ResourceName)
                    .HasColumnName("RESOURCE_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                     ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                     ;//.HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.ApiService)
                    .WithMany(p => p.ApiServiceOperations)
                    .HasForeignKey(d => d.ApiServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATON_SERVICE");
            });

            modelBuilder.Entity<ApiServices>(entity =>
            {
                entity.HasKey(e => e.ApiServiceId);

                entity.ToTable("API_SERVICES");

                entity.HasComment("API услуги");

                entity.HasIndex(e => e.AdministrationId)
                    .HasName("IFK1_API_SERVICES");

                entity.Property(e => e.ApiServiceId)
                    .HasColumnName("API_SERVICE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на API услуга")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdministrationId)
                    .HasColumnName("ADMINISTRATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на администрация");

                entity.Property(e => e.Assembly)
                    .IsRequired()
                    .HasColumnName("ASSEMBLY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Assembly DLL");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contract)
                    .IsRequired()
                    .HasColumnName("CONTRACT")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Contract");

                entity.Property(e => e.ControlerName)
                    .HasColumnName("CONTROLER_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                     ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                     ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasColumnName("ENABLED")
                    .HasComment("Достъпна");
                    //.HasDefaultValueSql("((1))")

                entity.Property(e => e.IsComplex)
                    .HasColumnName("IS_COMPLEX")
                    .HasComment("Комплексна услуга 0/1");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.ServiceUrl)
                    .IsRequired()
                    .HasColumnName("SERVICE_URL")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("URL на услуга");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.Administration)
                    .WithMany(p => p.ApiServices)
                    .HasForeignKey(d => d.AdministrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICE_ADMINISTRATION");
            });

            modelBuilder.Entity<AuditExceptions>(entity =>
            {
                entity.HasKey(e => e.AuditExceptionId)
                    .HasName("PK__AUDIT_EX__4017FBADFFCA8406");

                entity.ToTable("AUDIT_EXCEPTIONS");

                entity.Property(e => e.AuditExceptionId)
                    .HasColumnName("AUDIT_EXCEPTION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ActionMethod)
                    .HasColumnName("ACTION_METHOD")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .HasColumnName("CONTROLLER")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionText)
                    .HasColumnName("EXCEPTION_TEXT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionTime)
                    .HasColumnName("EXCEPTION_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(128)
                    ;//.HasDefaultValueSql("(CONVERT([nvarchar],connectionproperty('client_net_address')))");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuditTables>(entity =>
            {
                entity.ToTable("AUDIT_TABLES");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("ACTION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppName)
                    .HasColumnName("APP_NAME")
                    .HasMaxLength(128)
                    ;//.HasDefaultValueSql("(app_name())");

                entity.Property(e => e.AuditDate)
                    .HasColumnName("AUDIT_DATE")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(128)
                    ;//.HasDefaultValueSql("(CONVERT([nvarchar],connectionproperty('client_net_address')))");

                entity.Property(e => e.TableId)
                    .HasColumnName("TABLE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("TABLE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("numeric(20, 0)")
                    ;//.HasDefaultValueSql("(CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info())))");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");
            });

            modelBuilder.Entity<AuditUserActions>(entity =>
            {
                entity.HasKey(e => e.AuditUserActionId)
                    .HasName("PK__AUDIT_US__D8CE6C01AE585AB3");

                entity.ToTable("AUDIT_USER_ACTIONS");

                entity.Property(e => e.AuditUserActionId)
                    .HasColumnName("AUDIT_USER_ACTION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ActionMethod)
                    .HasColumnName("ACTION_METHOD")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ChangedTables)
                    .HasColumnName("CHANGED_TABLES")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .HasColumnName("CONTROLLER")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ExecuteStatus)
                    .HasColumnName("EXECUTE_STATUS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("IP_ADDRESS")
                    .HasMaxLength(128)
                    ;//.HasDefaultValueSql("(CONVERT([nvarchar],connectionproperty('client_net_address')))");

                entity.Property(e => e.Params)
                    .HasColumnName("PARAMS")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UserActionText)
                    .HasColumnName("USER_ACTION_TEXT")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserActionTime)
                    .HasColumnName("USER_ACTION_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserActionType)
                    .HasColumnName("USER_ACTION_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuditValues>(entity =>
            {
                entity.ToTable("AUDIT_VALUES");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AuditTableId)
                    .HasColumnName("AUDIT_TABLE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasColumnName("COLUMN_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewValue)
                    .HasColumnName("NEW_VALUE")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.OldValue)
                    .HasColumnName("OLD_VALUE")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.AuditTable)
                    .WithMany(p => p.AuditValues)
                    .HasForeignKey(d => d.AuditTableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AUDIT_VALUES_AUDIT_TABLES");
            });

            modelBuilder.Entity<CertificateAccessComments>(entity =>
            {
                entity.ToTable("CERTIFICATE_ACCESS_COMMENTS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("Идентификационен номер на таблицата.")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdapterOperationId)
                    .HasColumnName("ADAPTER_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на адаптер");

                entity.Property(e => e.ConsumerCertificateId)
                    .HasColumnName("CONSUMER_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на сертификат");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("CREATED_TIME")
                    .HasColumnType("datetime")
                    .HasComment("Време на създаване на описанието за редактиране на достъпа до елементите.");

                entity.Property(e => e.EditAccessComment)
                    .IsRequired()
                    .HasColumnName("EDIT_ACCESS_COMMENT")
                    .IsUnicode(false)
                    .HasComment("Описание на редактиране на достъпа до елементите.");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("Идентификационен номер на потребителя, който извършва редакцията.");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.CertificateAccessComments)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_ACCESS_COMMENTS_ADAPTER_OPERATIONS");

                entity.HasOne(d => d.ConsumerCertificate)
                    .WithMany(p => p.CertificateAccessComments)
                    .HasForeignKey(d => d.ConsumerCertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_ACCESS_COMMENTS_CONSUMER_CERTIFICATES");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CertificateAccessComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_ACCESS_COMMENTS_USERS");
            });

            modelBuilder.Entity<CertificateElementAccess>(entity =>
            {
                entity.ToTable("CERTIFICATE_ELEMENT_ACCESS");

                entity.HasIndex(e => e.ConsumerCertificateId)
                    .HasName("XIF1CONSUMER_CERTIFICATE_REGIS");

                entity.HasIndex(e => e.RegisterObjectElementId)
                    .HasName("XIF2CONSUMER_CERTIFICATE_REGIS");

                entity.HasIndex(e => new { e.ConsumerCertificateId, e.RegisterObjectElementId })
                    .HasName("UNI_CER_OPER_ACCESS")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ConsumerCertificateId)
                    .HasColumnName("CONSUMER_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на сертификат");

                entity.Property(e => e.HasAccess).HasColumnName("HAS_ACCESS");

                entity.Property(e => e.RegisterObjectElementId)
                    .HasColumnName("REGISTER_OBJECT_ELEMENT_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на елемент на обект");

                entity.HasOne(d => d.ConsumerCertificate)
                    .WithMany(p => p.CertificateElementAccess)
                    .HasForeignKey(d => d.ConsumerCertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_ELEMENT_ACCESS");

                entity.HasOne(d => d.RegisterObjectElement)
                    .WithMany(p => p.CertificateElementAccess)
                    .HasForeignKey(d => d.RegisterObjectElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ELEMENT_CERTIFICATE_ACCESS");
            });

            modelBuilder.Entity<CertificateOperationAccess>(entity =>
            {
                entity.ToTable("CERTIFICATE_OPERATION_ACCESS");

                entity.HasIndex(e => e.AdapterOperationId)
                    .HasName("XIF2CONSUMER_CERTIFICATE_ADAPT");

                entity.HasIndex(e => e.ConsumerCertificateId)
                    .HasName("XIF1CONSUMER_CERTIFICATE_ADAPT");

                entity.HasIndex(e => new { e.ConsumerCertificateId, e.AdapterOperationId })
                    .HasName("UNI_CER_OPER_ACCESS")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdapterOperationId)
                    .HasColumnName("ADAPTER_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на адаптер");

                entity.Property(e => e.ConsumerCertificateId)
                    .HasColumnName("CONSUMER_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на сертификат");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.HasAccess).HasColumnName("HAS_ACCESS");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.CertificateOperationAccess)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATON_CERTIFICATE_ACCESS");

                entity.HasOne(d => d.ConsumerCertificate)
                    .WithMany(p => p.CertificateOperationAccess)
                    .HasForeignKey(d => d.ConsumerCertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_OPERATON_ACCESS");
            });

            modelBuilder.Entity<ConsumerAccessRequests>(entity =>
            {
                entity.HasKey(e => e.ConsumerAccessRequestId);

                entity.ToTable("CONSUMER_ACCESS_REQUESTS");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.ConsumerAccessRequestId)
                    .HasColumnName("CONSUMER_ACCESS_REQUEST_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ConsumerSystemCertificateId)
                    .HasColumnName("CONSUMER_SYSTEM_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ConsumerRequestId)
                    .HasColumnName("CONSUMER_REQUEST_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.AdapterOperationId)
                    .HasColumnName("ADAPTER_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.LawReason)
                    .HasColumnName("LAW_REASON");

                entity.Property(e => e.RelatedServices)
                    .HasColumnName("RELATED_SERVICES");

                entity.Property(e => e.RelatedServicesCode)
                    .HasColumnName("RELATED_SERVICES_CODE");

                entity.HasOne(d => d.ConsumerSystemCertificate)
                    .WithMany(p => p.ConsumerAccessRequests)
                    .HasForeignKey(d => d.ConsumerSystemCertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_ACCESS_REQUESTS_CONSUMER_SYSTEM_CERTIFICATES");

                entity.HasOne(d => d.ConsumerRequest)
                    .WithMany(p => p.ConsumerAccessRequests)
                    .HasForeignKey(d => d.ConsumerRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_ACCESS_REQUESTS_CONSUMER_REQUESTS");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.ConsumerAccessRequests)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_ACCESS_REQUESTS_ADAPTER_OPERATIONS");
            });

            modelBuilder.Entity<ConsumerCertificateEids>(entity =>
            {
                entity.HasKey(e => e.ConsumerCertificateEidId)
                    .HasName("PK_CONSUMER_CERTIFICATE_EID");

                entity.ToTable("CONSUMER_CERTIFICATE_EIDS");

                entity.HasComment("Електронни идентичности на сертификат за ползвател");

                entity.HasIndex(e => e.ConsumerCertificateId)
                    .HasName("IFK1_CONSUMER_CERTIFICATE");

                entity.Property(e => e.ConsumerCertificateEidId)
                    .HasColumnName("CONSUMER_CERTIFICATE_EID_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на електронната идентичност на сертификат")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasComment("Активен");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("BIRTH_DATE")
                    .HasColumnType("datetime")
                    .HasComment("Дата на раждане");

                entity.Property(e => e.ConsumerCertificateId)
                    .HasColumnName("CONSUMER_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на сертификат");

                entity.Property(e => e.FamilyName)
                    .HasColumnName("FAMILY_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Фамилия");

                entity.Property(e => e.GivenName)
                    .HasColumnName("GIVEN_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Собствено име");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("MIDDLE_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Презиме");

                entity.Property(e => e.Spin)
                    .IsRequired()
                    .HasColumnName("SPIN")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Идентификационен номер");

                entity.HasOne(d => d.ConsumerCertificate)
                    .WithMany(p => p.ConsumerCertificateEids)
                    .HasForeignKey(d => d.ConsumerCertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_CERTIFICATE_EIDS");
            });

            modelBuilder.Entity<ConsumerCertificates>(entity =>
            {
                entity.HasKey(e => e.ConsumerCertificateId);

                entity.ToTable("CONSUMER_CERTIFICATES");

                entity.HasComment("Сертификати на ползватели");

                entity.HasIndex(e => e.ApiServiceConsumerId)
                    .HasName("IFK1_CONSUMER_CERTIFICATES");

                entity.HasIndex(e => e.Oid)
                    .HasName("UK_CONSUMER_CERTIFICATES")
                    .IsUnique()
                    .HasFilter("([ACTIVE]=(1) AND [OID] IS NOT NULL)");

                entity.Property(e => e.ConsumerCertificateId)
                    .HasColumnName("CONSUMER_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на сертификат")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("ACTIVE")
                    .HasComment("Активен");
                    //.HasDefaultValueSql("((1))")

                entity.Property(e => e.ApiServiceConsumerId)
                    .HasColumnName("API_SERVICE_CONSUMER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на ползвател");

                entity.Property(e => e.Content)
                    .HasColumnName("CONTENT")
                    .HasComment("Съдържание");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.IssuedFrom)
                    .HasColumnName("ISSUED_FROM")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Издаден от");

                entity.Property(e => e.IssuedTo)
                    .HasColumnName("ISSUED_TO")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Издаден на");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.Oid)
                    .HasColumnName("OID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Thumbprint)
                    .HasColumnName("THUMBPRINT")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Thumbprint");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.ValidFrom)
                    .HasColumnName("VALID_FROM")
                    .HasColumnType("datetime")
                    .HasComment("Валиден от");

                entity.Property(e => e.ValidTo)
                    .HasColumnName("VALID_TO")
                    .HasColumnType("datetime")
                    .HasComment("Валиден до");

                entity.HasOne(d => d.ApiServiceConsumer)
                    .WithMany(p => p.ConsumerCertificates)
                    .HasForeignKey(d => d.ApiServiceConsumerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_CONSUMER");
            });

            modelBuilder.Entity<ConsumerCertificatesReports>(entity =>
            {
                entity.HasKey(e => e.ConsumerCertificateReportId);

                entity.ToTable("CONSUMER_CERTIFICATES_REPORTS");

                entity.HasComment("Консуматори на справки");

                entity.Property(e => e.ConsumerCertificateReportId)
                    .HasColumnName("CONSUMER_CERTIFICATE_REPORT_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ConsumerCertificateId)
                    .HasColumnName("CONSUMER_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ReportId)
                    .HasColumnName("REPORT_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.HasOne(d => d.ConsumerCertificate)
                    .WithMany(p => p.ConsumerCertificatesReports)
                    .HasForeignKey(d => d.ConsumerCertificateId)
                    .HasConstraintName("FK_CONSUMER_CERTIFICATES_REPORTS_CONSUMER_CERTIFICATES");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ConsumerCertificatesReports)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_CONSUMER_CERTIFICATES_REPORTS_REPORTS");
            });
            
            modelBuilder.Entity<ConsumerProfileStatus>(entity =>
            {
                entity.HasKey(e => e.ConsumerProfileStatusId);

                entity.ToTable("CONSUMER_PROFILE_STATUS");

                entity.Property(e => e.ConsumerProfileStatusId)
                    .HasColumnName("CONSUMER_PROFILE_STATUS_ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("COMMENT");

                entity.Property(e => e.ConsumerProfileId)
                    .HasColumnName("CONSUMER_PROFILE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewStatus).HasColumnName("NEW_STATUS");

                entity.Property(e => e.OldStatus).HasColumnName("OLD_STATUS");

                entity.HasOne(d => d.ConsumerProfile)
                    .WithMany(p => p.ConsumerProfileStatus)
                    .HasForeignKey(d => d.ConsumerProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_PROFILE_STATUS_CONSUMER_PROFILES");
            });

            modelBuilder.Entity<ConsumerProfileUsers>(entity =>
            {
                entity.HasKey(e => e.ConsumerProfileUserId);

                entity.ToTable("CONSUMER_PROFILE_USERS");

                entity.Property(e => e.AccessFailedCount).HasColumnName("ACCESS_FAILED_COUNT");

                entity.Property(e => e.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");

                entity.Property(e => e.ConsumerProfileId)
                    .HasColumnName("CONSUMER_PROFILE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ConsumerProfileUserId)
                    .HasColumnName("CONSUMER_PROFILE_USER_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailConfirmed).HasColumnName("EMAIL_CONFIRMED");

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("IDENTIFIER")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdentifierType).HasColumnName("IDENTIFIER_TYPE");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.LockoutEnabled).HasColumnName("LOCKOUT_ENABLED");

                entity.Property(e => e.LockoutEnd).HasColumnName("LOCKOUT_END");

                entity.Property(e => e.Name).HasColumnName("NAME");

                entity.Property(e => e.NormalizedEmail)
                    .HasColumnName("NORMALIZED_EMAIL")
                    .HasMaxLength(256);

                entity.Property(e => e.PasswordHash).HasColumnName("PASSWORD_HASH");

                entity.Property(e => e.PhoneNumber).HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("PHONE_NUMBER_CONFIRMED");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("POSITION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityStamp).HasColumnName("SECURITY_STAMP");

                entity.Property(e => e.TwoFactorEnabled).HasColumnName("TWO_FACTOR_ENABLED");

                entity.HasOne(d => d.ConsumerProfile)
                    .WithMany(p => p.ConsumerProfileUsers)
                    .HasForeignKey(d => d.ConsumerProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_PROFILE_USERS_CONSUMER_PROFILES");
            });

            modelBuilder.Entity<ConsumerProfiles>(entity =>
            {
                entity.HasKey(e => e.ConsumerProfileId);

                entity.ToTable("CONSUMER_PROFILES");

                entity.Property(e => e.ConsumerProfileId)
                    .HasColumnName("CONSUMER_PROFILE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.AcceptedEula).HasColumnName("ACCEPTED_EULA");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.AdministrationId)
                    .HasColumnName("ADMINISTRATION_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.DocumentNumber)
                    .HasColumnName("DOCUMENT_NUMBER")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("IDENTIFIER")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdentifierType).HasColumnName("IDENTIFIER_TYPE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityStamp).HasColumnName("SECURITY_STAMP");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.HasOne(d => d.Administration)
                    .WithMany(p => p.ConsumerProfiles)
                    .HasForeignKey(d => d.AdministrationId)
                    .HasConstraintName("FK_CONSUMER_PROFILES_ADMINISTRATIONS");
            });

            modelBuilder.Entity<ConsumerRequestElements>(entity =>
            {
                entity.ToTable("CONSUMER_REQUEST_ELEMENTS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ConsumerAccessRequestId)
                    .HasColumnName("CONSUMER_ACCESS_REQUEST_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на сертификат");

                entity.Property(e => e.RegisterObjectElementId)
                    .HasColumnName("REGISTER_OBJECT_ELEMENT_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на елемент на обект");

                entity.HasOne(d => d.ConsumerAccessRequest)
                    .WithMany(p => p.ConsumerRequestElements)
                    .HasForeignKey(d => d.ConsumerAccessRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_REQUEST_ELEMENTS_CONSUMER_ACCESS_REQUESTS");

                entity.HasOne(d => d.RegisterObjectElement)
                    .WithMany(p => p.ConsumerRequestElements)
                    .HasForeignKey(d => d.RegisterObjectElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_REQUEST_ELEMENTS_REGISTER_OBJECT_ELEMENTS");
            });

            modelBuilder.Entity<ConsumerSystemCertificates>(entity =>
            {
                entity.HasKey(e => e.ConsumerSystemCertificateId);

                entity.ToTable("CONSUMER_SYSTEM_CERTIFICATES");

                entity.Property(e => e.ConsumerSystemCertificateId)
                    .HasColumnName("CONSUMER_SYSTEM_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ConsumerCertificateId)
                    .HasColumnName("CONSUMER_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ConsumerSystemId)
                    .HasColumnName("CONSUMER_SYSTEM_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Content)
                    .HasColumnName("CONTENT")
                    .HasComment("Съдържание");

                entity.Property(e => e.Csr).HasColumnName("CSR");

                entity.Property(e => e.Environment)
                    .IsRequired()
                    .HasColumnName("ENVIRONMENT")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RequestDate)
                    .HasColumnName("REQUEST_DATE")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ConsumerCertificate)
                    .WithMany(p => p.ConsumerSystemCertificates)
                    .HasForeignKey(d => d.ConsumerCertificateId)
                    .HasConstraintName("FK_CONSUMER_SYSTEM_CERTIFICATES_CONSUMER_CERTIFICATES");

                entity.HasOne(d => d.ConsumerSystem)
                    .WithMany(p => p.ConsumerSystemCertificates)
                    .HasForeignKey(d => d.ConsumerSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_SYSTEM_CERTIFICATES_CONSUMER_SYSTEMS");
            });

            modelBuilder.Entity<ConsumerSystems>(entity =>
            {
                entity.HasKey(e => e.ConsumerSystemId);

                entity.ToTable("CONSUMER_SYSTEMS");

                entity.Property(e => e.ConsumerSystemId)
                    .HasColumnName("CONSUMER_SYSTEM_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ApiServiceConsumerId)
                    .HasColumnName("API_SERVICE_CONSUMER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на ползвател");

                entity.Property(e => e.ConsumerProfileId)
                    .HasColumnName("CONSUMER_PROFILE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StaticIP)
                    .HasColumnName("STATIC_IP")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApiServiceConsumer)
                    .WithMany(p => p.ConsumerSystems)
                    .HasForeignKey(d => d.ApiServiceConsumerId)
                    .HasConstraintName("FK_CONSUMER_SYSTEMS_API_SERVICE_CONSUMERS");

                entity.HasOne(d => d.ConsumerProfile)
                    .WithMany(p => p.ConsumerSystems)
                    .HasForeignKey(d => d.ConsumerProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_SYSTEMS_CONSUMER_PROFILES");
            });

            modelBuilder.Entity<CustomParameters>(entity =>
            {
                entity.ToTable("CUSTOM_PARAMETERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsRequired).HasColumnName("IS_REQUIRED");

                entity.Property(e => e.Label)
                    .HasColumnName("LABEL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OperationParameterId)
                    .HasColumnName("OPERATION_PARAMETER_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Order).HasColumnName("ORDER");

                entity.Property(e => e.RegexExpression)
                    .HasColumnName("REGEX_EXPRESSION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportId)
                    .HasColumnName("REPORT_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.HasOne(d => d.OperationParameter)
                    .WithMany(p => p.CustomParameters)
                    .HasForeignKey(d => d.OperationParameterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOM_PARAMETERS_OPERATION_PARAMETERS");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.CustomParameters)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOM_PARAMETERS_REPORTS");
            });

            modelBuilder.Entity<HealthServiceLog>(entity =>
            {
                entity.ToTable("HEALTH_SERVICE_LOG");

                entity.Property(e => e.HealthServiceLogId).HasColumnName("HEALTH_SERVICE_LOG_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .IsUnicode(false);

                entity.Property(e => e.ServiceName)
                    .HasColumnName("SERVICE_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasColumnName("TIME")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<HealthServiceOffline>(entity =>
            {
                entity.ToTable("HEALTH_SERVICE_OFFLINE");

                entity.Property(e => e.HealthServiceOfflineId).HasColumnName("HEALTH_SERVICE_OFFLINE_ID");

                entity.Property(e => e.EndPeriod)
                    .HasColumnName("END_PERIOD")
                    .HasColumnType("datetime");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasColumnName("SERVICE_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartPeriod)
                    .HasColumnName("START_PERIOD")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<HealthServicePing>(entity =>
            {
                entity.ToTable("HEALTH_SERVICE_PING");

                entity.Property(e => e.HealthServicePingId).HasColumnName("HEALTH_SERVICE_PING_ID");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasColumnName("SERVICE_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Time)
                    .HasColumnName("TIME")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OperationParameters>(entity =>
            {
                entity.ToTable("OPERATION_PARAMETERS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsRequired).HasColumnName("IS_REQUIRED");

                entity.Property(e => e.Label)
                    .HasColumnName("LABEL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Order).HasColumnName("ORDER");

                entity.Property(e => e.ParameterTypeId)
                    .HasColumnName("PARAMETER_TYPE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.RegexExpression)
                    .HasColumnName("REGEX_EXPRESSION")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceOperationId)
                    .HasColumnName("SERVICE_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.HasOne(d => d.ParameterType)
                    .WithMany(p => p.OperationParameters)
                    .HasForeignKey(d => d.ParameterTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATION_PARAMETERS_PARAMETER_TYPES");

                entity.HasOne(d => d.ServiceOperation)
                    .WithMany(p => p.OperationParameters)
                    .HasForeignKey(d => d.ServiceOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATION_PARAMETERS_API_SERVICE_OPERATIONS");
            });

            modelBuilder.Entity<OperationsErrorLog>(entity =>
            {
                entity.ToTable("OPERATIONS_ERROR_LOG");

                entity.HasIndex(e => e.ApiServiceCallId)
                    .HasName("IX_OPERATIONS_ERROR_LOG_CALL_ID");

                entity.Property(e => e.OperationsErrorLogId)
                    .HasColumnName("OPERATIONS_ERROR_LOG_ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdapterOperationId)
                    .HasColumnName("ADAPTER_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на адаптер");

                entity.Property(e => e.ApiServiceCallId)
                    .HasColumnName("API_SERVICE_CALL_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("Идентификатор на извикването, при което е възникнала тази грешка");

                entity.Property(e => e.ApiServiceOperationId)
                    .HasColumnName("API_SERVICE_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на услуга");

                entity.Property(e => e.ErrorContent)
                    .HasColumnName("ERROR_CONTENT")
                    .IsUnicode(false);

                entity.Property(e => e.ErrorMessage)
                    .HasColumnName("ERROR_MESSAGE")
                    .IsUnicode(false);

                entity.Property(e => e.LogTime)
                    .HasColumnName("LOG_TIME")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.OperationsErrorLog)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .HasConstraintName("FK_ERROR_ADAPTER_OPERATIONS");

                entity.HasOne(d => d.ApiServiceCall)
                    .WithMany(p => p.OperationsErrorLog)
                    .HasForeignKey(d => d.ApiServiceCallId)
                    .HasConstraintName("FK_OPERATIONS_ERROR_LOG_API_SERVICE_CALLS");

                entity.HasOne(d => d.ApiServiceOperation)
                    .WithMany(p => p.OperationsErrorLog)
                    .HasForeignKey(d => d.ApiServiceOperationId)
                    .HasConstraintName("FK_ERROR_SERVICE_OPERATIONS");
            });

            modelBuilder.Entity<ParameterTypes>(entity =>
            {
                entity.ToTable("PARAMETER_TYPES");

                entity.HasIndex(e => e.Id)
                    .HasName("UniqueID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnumValues)
                    .HasColumnName("ENUM_VALUES")
                    .IsUnicode(false);

                entity.Property(e => e.IsEnum).HasColumnName("IS_ENUM");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParametersValuesLog>(entity =>
            {
                entity.ToTable("PARAMETERS_VALUES_LOG");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("Идентификационен номер на таблицата")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EditedTime)
                    .HasColumnName("EDITED_TIME")
                    .HasColumnType("datetime")
                    .HasComment("Време на извършената промяна на стойността");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("KEY")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Име на параметъра");

                entity.Property(e => e.NewValue)
                    .HasColumnName("NEW_VALUE")
                    .IsUnicode(false)
                    .HasComment("Нова стойност на параметъра");

                entity.Property(e => e.OldValue)
                    .HasColumnName("OLD_VALUE")
                    .IsUnicode(false)
                    .HasComment("Стара стойност на параметъра");

                entity.Property(e => e.RegisterAdapterId)
                    .HasColumnName("REGISTER_ADAPTER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("Идентификационен номер на адаптера");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("Идентификационен номер на потребителя извършил промяната");

                entity.HasOne(d => d.RegisterAdapter)
                    .WithMany(p => p.ParametersValuesLog)
                    .HasForeignKey(d => d.RegisterAdapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMETERS_VALUES_LOG_REGISTER_ADAPTERS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ParametersValuesLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMETERS_VALUES_EDIT_USERS");
            });
            
            modelBuilder.Entity<RegisterAdapters>(entity =>
            {
                entity.HasKey(e => e.RegisterAdapterId);

                entity.ToTable("REGISTER_ADAPTERS");

                entity.HasComment("Адаптери на регистри");

                entity.HasIndex(e => e.RegisterId)
                    .HasName("IFK1_REGISTER_ADAPTERS");

                entity.Property(e => e.RegisterAdapterId)
                    .HasColumnName("REGISTER_ADAPTER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на адаптер на регистър")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdapterUrl)
                    .IsRequired()
                    .HasColumnName("ADAPTER_URL")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("URL на адаптер");

                entity.Property(e => e.Assembly)
                    .IsRequired()
                    .HasColumnName("ASSEMBLY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Assembly на адаптер");

                entity.Property(e => e.Behaviour)
                    .HasColumnName("BEHAVIOUR")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Behaviour");

                entity.Property(e => e.BindingConfigName)
                    .IsRequired()
                    .HasColumnName("BINDING_CONFIG_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Binding");

                entity.Property(e => e.BindingType)
                    .IsRequired()
                    .HasColumnName("BINDING_TYPE")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Binding Type");

                entity.Property(e => e.Contract)
                    .IsRequired()
                    .HasColumnName("CONTRACT")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Contract");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.RegisterId)
                    .HasColumnName("REGISTER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на регистър");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Version)
                    .HasColumnName("VERSION")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Версия на адаптер");

                entity.HasOne(d => d.Register)
                    .WithMany(p => p.RegisterAdapters)
                    .HasForeignKey(d => d.RegisterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADAPTER_REGISTER");
            });

            modelBuilder.Entity<RegisterObjectElements>(entity =>
            {
                entity.HasKey(e => e.RegisterObjectElementId);

                entity.ToTable("REGISTER_OBJECT_ELEMENTS");

                entity.HasComment("Елементи на обекти на регистри");

                entity.HasIndex(e => e.RegisterObjectId)
                    .HasName("IFK1_REGISTER_OBJECT_ELEMENTS");

                entity.Property(e => e.RegisterObjectElementId)
                    .HasColumnName("REGISTER_OBJECT_ELEMENT_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на елемент на обект")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.PathToRoot)
                    .IsRequired()
                    .HasColumnName("PATH_TO_ROOT")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Пълен път до началото");

                entity.Property(e => e.RegisterObjectId)
                    .HasColumnName("REGISTER_OBJECT_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на обект на регистър");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.RegisterObject)
                    .WithMany(p => p.RegisterObjectElements)
                    .HasForeignKey(d => d.RegisterObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ELEMENT_OBJECT");
            });

            modelBuilder.Entity<RegisterObjects>(entity =>
            {
                entity.HasKey(e => e.RegisterObjectId);

                entity.ToTable("REGISTER_OBJECTS");

                entity.HasComment("Обекти на регистър");

                entity.HasIndex(e => e.RegisterAdapterId)
                    .HasName("XIF1REGISTER_OBJECT");

                entity.Property(e => e.RegisterObjectId)
                    .HasColumnName("REGISTER_OBJECT_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на обект на регистър")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Content)
                    .HasColumnName("CONTENT")
                    .HasComment("Съдържание");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("FULL_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Пълно име");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.RegisterAdapterId)
                    .HasColumnName("REGISTER_ADAPTER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на адаптер на регистър");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Xslt).HasColumnName("XSLT");

                entity.HasOne(d => d.RegisterAdapter)
                    .WithMany(p => p.RegisterObjects)
                    .HasForeignKey(d => d.RegisterAdapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGISTER_OBJECT_ADAPTER");
            });

            modelBuilder.Entity<RegisterObjectsLog>(entity =>
            {
                entity.ToTable("REGISTER_OBJECTS_LOG");

                entity.Property(e => e.RegisterObjectsLogId)
                    .HasColumnName("REGISTER_OBJECTS_LOG_ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateLastModifyed)
                    .HasColumnName("DATE_LAST_MODIFYED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.PathToRoot)
                    .IsRequired()
                    .HasColumnName("PATH_TO_ROOT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterAdapterId)
                    .HasColumnName("REGISTER_ADAPTER_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.RegisterObjectElementId)
                    .HasColumnName("REGISTER_OBJECT_ELEMENT_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.RegisterObjectId)
                    .HasColumnName("REGISTER_OBJECT_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.RegisterObjectsFullName)
                    .IsRequired()
                    .HasColumnName("REGISTER_OBJECTS_FULL_NAME")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.RegisterObjectsName)
                    .IsRequired()
                    .HasColumnName("REGISTER_OBJECTS_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreated)
                    .HasColumnName("USER_CREATED")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserModifyed)
                    .HasColumnName("USER_MODIFYED")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Registers>(entity =>
            {
                entity.HasKey(e => e.RegisterId);

                entity.ToTable("REGISTERS");

                entity.HasComment("Регистри");

                entity.HasIndex(e => e.AdministrationId)
                    .HasName("IFK1_REGISTERS");

                entity.Property(e => e.RegisterId)
                    .HasColumnName("REGISTER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на регистър")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdministrationId)
                    .HasColumnName("ADMINISTRATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на администрация");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.Administration)
                    .WithMany(p => p.Registers)
                    .HasForeignKey(d => d.AdministrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGISTER_ADMINISTRATION");
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.HasKey(e => e.ReportId);

                entity.ToTable("REPORTS");

                entity.Property(e => e.ReportId)
                    .HasColumnName("REPORT_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ApiServiceConsumerId)
                    .HasColumnName("API_SERVICE_CONSUMER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("Консуматор по подразбиране(информативно)");

                entity.Property(e => e.ApiServiceOperationId)
                    .HasColumnName("API_SERVICE_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Claim)
                    .HasColumnName("CLAIM")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LawReason)
                    .HasColumnName("LAW_REASON")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNumber).HasColumnName("ORDER_NUMBER");

                entity.Property(e => e.Xslt).HasColumnName("XSLT");

                entity.HasOne(d => d.ApiServiceConsumer)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ApiServiceConsumerId)
                    .HasConstraintName("FK_REPORTS_API_SERVICE_CONSUMERS");

                entity.HasOne(d => d.ApiServiceOperation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ApiServiceOperationId)
                    .HasConstraintName("FK_REPORTS_API_SERVICE_OPERATIONS");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("USERS");

                entity.HasIndex(e => e.AdministrationId)
                    .HasName("IKF1_USERS");

                entity.HasIndex(e => e.UserName)
                    .HasName("CK_USER_NAME")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на потребител")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE")
                    .HasComment("Активен");

                entity.Property(e => e.AdministrationId)
                    .HasColumnName("ADMINISTRATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на администрация");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasComment("Дата на създаване");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Email");

                entity.Property(e => e.FailedPswdAnsAtmpCount)
                    .HasColumnName("FAILED_PSWD_ANS_ATMP_COUNT")
                    .HasColumnType("numeric(10, 0)")
                    .HasComment("Брой грешно отговорени въпроси за парола");

                entity.Property(e => e.FailedPswdAnsAtmpWdwStart)
                    .HasColumnName("FAILED_PSWD_ANS_ATMP_WDW_START")
                    .HasColumnType("datetime")
                    .HasComment("Начало на брой грешно отговорени въпроси за парола");

                entity.Property(e => e.FailedPswdAtmpCount)
                    .HasColumnName("FAILED_PSWD_ATMP_COUNT")
                    .HasColumnType("numeric(10, 0)")
                    .HasComment("Брой грешни пароли");

                entity.Property(e => e.FailedPswdAtmpWdwStart)
                    .HasColumnName("FAILED_PSWD_ATMP_WDW_START")
                    .HasColumnType("datetime")
                    .HasComment("Начало на броене на грешни пароли");

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("IS_ADMIN")
                    .HasComment("Администратор на RegiX");

                entity.Property(e => e.IsAnonymous)
                    .HasColumnName("IS_ANONYMOUS")
                    .HasComment("Анонимен");

                entity.Property(e => e.IsApproved)
                    .HasColumnName("IS_APPROVED")
                    .HasComment("Одобрен");

                entity.Property(e => e.IsLockedOut)
                    .HasColumnName("IS_LOCKED_OUT")
                    .HasComment("Заключен");

                entity.Property(e => e.LastActivityDate)
                    .HasColumnName("LAST_ACTIVITY_DATE")
                    .HasColumnType("datetime")
                    .HasComment("Последна дата на активност");

                entity.Property(e => e.LastLockoutDate)
                    .HasColumnName("LAST_LOCKOUT_DATE")
                    .HasColumnType("datetime")
                    .HasComment("Последна дата на заключване");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnName("LAST_LOGIN_DATE")
                    .HasColumnType("datetime")
                    .HasComment("Последно влизане");

                entity.Property(e => e.LastPasswordChangedDate)
                    .HasColumnName("LAST_PASSWORD_CHANGED_DATE")
                    .HasColumnType("datetime")
                    .HasComment("Последна смяна на парола");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Име на потребителя");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Парола");

                entity.Property(e => e.PasswordAnswer)
                    .HasColumnName("PASSWORD_ANSWER")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Отговор на въпрос за парола");

                entity.Property(e => e.PasswordQuestion)
                    .HasColumnName("PASSWORD_QUESTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Въпрос на парола");

                entity.Property(e => e.PswdVerTokenExpirationDate)
                    .HasColumnName("PSWD_VER_TOKEN_EXPIRATION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.PswdVerificationToken)
                    .HasColumnName("PSWD_VERIFICATION_TOKEN")
                    .HasMaxLength(128);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    ;//.HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    ;//.HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.UserComment)
                    .HasColumnName("USER_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Коментар");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Потребителско име");

                entity.HasOne(d => d.Administration)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AdministrationId)
                    .HasConstraintName("FK_USER_ADMINISTRATION");
            });


            modelBuilder.Entity<UsersEAuth>(entity =>
            {
                entity.ToTable("USERS_EAUTH");

                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("IDENTIFIER")
                    .HasMaxLength(50);

                entity.Property(e => e.IdentifierType)
                    .IsRequired()
                    .HasColumnName("IDENTIFIER_TYPE")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UserEAuth)
                    .HasForeignKey<UsersEAuth>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.USERS_EAUTH_dbo.USERS_USER_ID");
            });


            modelBuilder.Entity<CertificateConsumerRole>(entity =>
            {
                entity.ToTable("CERTIFICATE_CONSUMER_ROLE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("Идентификационен номер на таблицата.")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ConsumerCertificateId)
                    .HasColumnName("CONSUMER_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на сертификат");

                entity.Property(e => e.ConsumerRoleId)
                    .HasColumnName("CONSUMER_ROLE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на роля на консуматор");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("CREATED_TIME")
                    .HasColumnType("datetime")
                    .HasComment("Време на създаване на описанието за редактиране на достъпа до елементите.");

                entity.Property(e => e.EditAccessComment)
                    .IsRequired()
                    .HasColumnName("EDIT_ACCESS_COMMENT")
                    .IsUnicode(false)
                    .HasComment("Описание на предоставяне на достъп до роля на консуматор");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("Идентификационен номер на потребителя, който извършва редакцията.");

                entity.HasOne(d => d.ConsumerCertificate)
                    .WithMany(p => p.CertificateConsumerRole)
                    .HasForeignKey(d => d.ConsumerCertificateId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_CERTIFICATE_CONSUMER_ROLE_CONSUMER_CERTIFICATES");

                entity.HasOne(d => d.ConsumerRole)
                    .WithMany(p => p.CertificateConsumerRole)
                    .HasForeignKey(d => d.ConsumerRoleId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_CERTIFICATE_CONSUMER_ROLE_CONSUMER_ROLES");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CertificateConsumerRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_CERTIFICATE_CONSUMER_ROLE_USERS");
            });
            modelBuilder.Entity<ConsumerRoleElementAccess>(entity =>
            {
                entity.ToTable("CONSUMER_ROLE_ELEMENT_ACCESS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ConsumerRoleId)
                    .HasColumnName("CONSUMER_ROLE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на роля на консуматор");

                entity.Property(e => e.HasAccess).HasColumnName("HAS_ACCESS");

                entity.Property(e => e.RegisterObjectElementId)
                    .HasColumnName("REGISTER_OBJECT_ELEMENT_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на елемент на обект");

                entity.HasOne(d => d.ConsumerRole)
                    .WithMany(p => p.ConsumerRoleElementAccess)
                    .HasForeignKey(d => d.ConsumerRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_ROLE_ELEMENT_ACCESS");

                entity.HasOne(d => d.RegisterObjectElement)
                    .WithMany(p => p.ConsumerRoleElementAccess)
                    .HasForeignKey(d => d.RegisterObjectElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ELEMENT_CONSUMER_ROLE_ACCESS");
            });

            modelBuilder.Entity<ConsumerRoleOperationAccess>(entity =>
            {
                entity.ToTable("CONSUMER_ROLE_OPERATION_ACCESS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdapterOperationId)
                    .HasColumnName("ADAPTER_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на операция на адаптер");

                entity.Property(e => e.ConsumerRoleId)
                    .HasColumnName("CONSUMER_ROLE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на роля на консуматор");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.HasAccess).HasColumnName("HAS_ACCESS");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.ConsumerRoleOperationAccess)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATON_CONSUMER_ROLE_ACCESS");

                entity.HasOne(d => d.ConsumerRole)
                    .WithMany(p => p.ConsumerRoleOperationAccess)
                    .HasForeignKey(d => d.ConsumerRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_ROLE_OPERATON_ACCESS");
            });
            
            modelBuilder.Entity<ConsumerRoles>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("CONSUMER_ROLES");

                entity.Property(e => e.Id)
                    .HasColumnName("CONSUMER_ROLE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .HasComment("ID на роля на консуматор")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Описание");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Наименование");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");
            });


            modelBuilder.Entity<StatisticsOutput>(entity =>
            {
                entity.HasKey(e => new {
                    e.ConsumerAdministration,
                    e.ConsumerName,
                    e.RegisterAdministration,
                    e.RegisterName,
                    e.OperationName,
                    e.RecordsCount,
                    e.ApiServiceId,
                    e.ConsumerId,
                    e.ApiServiceOperationId,
                    e.AdministrationId,
                    e.ConsumerAdministrationId,
                    e.RegisterId,
                    e.AdapterId,
                    e.AdapterOperationId
                });

                entity.Property(e => e.ApiServiceOperationId)
                    .HasColumnName("API_SERVICE_OPERATION_ID");

                entity.Property(e => e.AdapterId)
                    .HasColumnName("AdapterId");

                entity.Property(e => e.AdapterOperationId)
                    .HasColumnName("AdapterOperationId");

                entity.Property(e => e.AdministrationId)
                    .HasColumnName("AdministrationId");

                entity.Property(e => e.ApiServiceId)
                    .HasColumnName("ApiServiceId");

                entity.Property(e => e.ConsumerAdministration)
                    .HasColumnName("ConsumerAdministration");

                entity.Property(e => e.ConsumerAdministrationId)
                    .HasColumnName("ConsumerAdministrationId");

                entity.Property(e => e.ConsumerId)
                    .HasColumnName("ConsumerId");

                entity.Property(e => e.ConsumerName)
                    .HasColumnName("ConsumerName");

                entity.Property(e => e.OperationName)
                    .HasColumnName("OperationName");

                entity.Property(e => e.RecordsCount)
                    .HasColumnName("RecordsCount");

                entity.Property(e => e.RegisterAdministration)
                    .HasColumnName("RegisterAdministration");

                entity.Property(e => e.RegisterId)
                    .HasColumnName("RegisterId");

                entity.Property(e => e.RegisterName)
                    .HasColumnName("RegisterName");
            });

            modelBuilder.Entity<ConsumerRequestOperationDb>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AdministrationName)
                    .HasColumnName("AdministrationName");

                entity.Property(e => e.AdapterName)
                    .HasColumnName("AdapterName");

                entity.Property(e => e.RegisterName)
                    .HasColumnName("RegisterName");
            });

            modelBuilder.Entity<CertificateOperationAccessExtended>(entity =>
            {
                entity.HasKey(e => e.CertificateOperationAccessId);

                entity.ToTable("CERTIFICATE_OPERATION_ACCESS_EXTENDED");
                entity.Property(e => e.CertificateOperationAccessId).HasColumnName("CERTIFICATE_OPERATION_ACCESS_ID");
                entity.Property(e => e.CertificateOperationAccessHasAccess)
                    .HasColumnName("CERTIFICATE_OPERATION_ACCESS_HAS_ACCESS");
                entity.Property(e => e.AdapterOperationName).HasColumnName("ADAPTER_OPERATION_NAME");
                entity.Property(e => e.AdapterOperationDescription).HasColumnName("ADAPTER_OPERATION_DESCRIPTION");
                entity.Property(e => e.RegisterObjectName).HasColumnName("REGISTER_OBJECT_NAME");
                entity.Property(e => e.RegisterObjectFullName).HasColumnName("REGISTER_OBJECT_FULL_NAME");
                entity.Property(e => e.RegisterObjectDescription).HasColumnName("REGISTER_OBJECT_DESCRIPTION");
                entity.Property(e => e.RegisterObjectContent).HasColumnName("REGISTER_OBJECT_CONTENT");
                entity.Property(e => e.RegisterObjectXslt).HasColumnName("REGISTER_OBJECT_XSLT");
            });

            modelBuilder.Entity<ConsumerRequestStatus>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("CONSUMER_REQUEST_STATUS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Comment).HasColumnName("COMMENT");

                entity.Property(e => e.ConsumerRequestId)
                    .HasColumnName("CONSUMER_REQUEST_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewStatus).HasColumnName("NEW_STATUS");

                entity.Property(e => e.OldStatus).HasColumnName("OLD_STATUS");

                entity.HasOne(d => d.ConsumerRequest)
                    .WithMany(p => p.ConsumerRequestStatus)
                    .HasForeignKey(d => d.ConsumerRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_REQUEST_STATUS_CONSUMER_REQUESTS");
            });

            modelBuilder.Entity<ConsumerRequests>(entity =>
            {
                entity.HasKey(e => e.ConsumerRequestId);

                entity.ToTable("CONSUMER_REQUESTS");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.ConsumerRequestId)
                    .HasColumnName("CONSUMER_REQUEST_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ConsumerProfileId)
                    .HasColumnName("CONSUMER_PROFILE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ConsumerSystemId)
                    .HasColumnName("CONSUMER_SYSTEM_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.DocumentNumber)
                    .HasColumnName("DOCUMENT_NUMBER")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OutDocumentNumber)
                    .HasColumnName("OUT_DOCUMENT_NUMBER")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(true);

                entity.HasOne(d => d.ConsumerProfile)
                    .WithMany(p => p.ConsumerRequests)
                    .HasForeignKey(d => d.ConsumerProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_REQUESTS_CONSUMER_PROFILES");
                entity.HasOne(d => d.ConsumerSystem)
                    .WithMany(p => p.ConsumerRequests)
                    .HasForeignKey(d => d.ConsumerSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_REQUESTS_CONSUMER_SYSTEMS");
            });

            modelBuilder
               .Query<AccessReportFilterView>()
                .ToView("PrimaryAdminFilterView");

            modelBuilder
                .Query<AccessReportFilterConsumerView>()
                .ToView("ConsumerFilterView");

            modelBuilder
                .Query<GetElementConsumersViewOutput>()
                .ToView("GetElementConsumers");

            modelBuilder
                .Query<GetElementConsumersElementsViewOutput>()
                .ToView("GetElementConsumersWithElements");

            modelBuilder
                .Query<ApiServiceCallViewOutput>()
                .ToView("ApiServiceCallsFilterNew");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}