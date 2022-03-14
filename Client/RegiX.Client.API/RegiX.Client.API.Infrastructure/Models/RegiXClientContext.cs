using Microsoft.EntityFrameworkCore;
using TechnoLogica.RegiX.Client.Infrastructure.Models.DatabaseObjectModels;
using TechnoLogica.RegiX.Client.Repositories;

namespace TechnoLogica.RegiX.Client.Infrastructure.Models
{
    public partial class RegiXClientContext : DbContext
    {
        protected IUserContext UserContext { get; private set; }
        public RegiXClientContext()
        {
        }

        public RegiXClientContext(DbContextOptions<RegiXClientContext> options, IUserContext userContext)
            : base(options)
        {
            UserContext = userContext;
            this.Database.GetDbConnection().StateChange += OnConnectionOpened;
        }

        public virtual DbSet<AdapterOperations> AdapterOperations { get; set; }
        public virtual DbSet<AuditExceptions> AuditExceptions { get; set; }
        public virtual DbSet<AuditReportExecutions> AuditReportExecutions { get; set; }
        public virtual DbSet<AuditSystemReportExecutions> AuditSystemReportExecutions { get; set; }
        public virtual DbSet<AuditTables> AuditTables { get; set; }
        public virtual DbSet<AuditUserActions> AuditUserActions { get; set; }
        public virtual DbSet<AuditValues> AuditValues { get; set; }
        public virtual DbSet<Authorities> Authorities { get; set; }
        public virtual DbSet<EnumItems> EnumItems { get; set; }
        public virtual DbSet<EnumItemsToParameterTypes> EnumItemsToParameterTypes { get; set; }
        public virtual DbSet<FederationUsers> FederationUsers { get; set; }
        public virtual DbSet<LocalUsers> LocalUsers { get; set; }
        public virtual DbSet<ParameterTypes> ParameterTypes { get; set; }
        public virtual DbSet<Parameters> Parameters { get; set; }
        public virtual DbSet<ParametersToOperation> ParametersToOperation { get; set; }
        public virtual DbSet<PublicUsers> PublicUsers { get; set; }
        public virtual DbSet<Registers> Registers { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesToReports> RolesToReports { get; set; }
        public virtual DbSet<UserEiks> UserEiks { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersToRoles> UsersToRoles { get; set; }
        public virtual DbSet<AsyncReportExecutions> AsyncReportExecutions { get; set; }
        //public virtual DbSet<UsersToReports> UsersToReports { get; set; }
        public virtual DbSet<ReportsForUsersView> ReportsForUsersView { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(
                    "Server=regix2-sql.regix.tlogica.com;initial catalog=regix2ClientDevMultitenant;persist security info=True;user id=;password=;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AdapterOperations>(entity =>
            {
                entity.ToTable("ADAPTER_OPERATIONS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100);

                entity.Property(e => e.ControllerName)
                    .IsRequired()
                    .HasColumnName("CONTROLLER_NAME")
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisplayOperationName)
                    .IsRequired()
                    .HasColumnName("DISPLAY_OPERATION_NAME")
                    .HasMaxLength(2000);

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Namespace)
                    .IsRequired()
                    .HasColumnName("NAMESPACE")
                    .HasMaxLength(500);

                entity.Property(e => e.OperationName)
                    .IsRequired()
                    .HasColumnName("OPERATION_NAME")
                    .HasMaxLength(2000);

                entity.Property(e => e.RegisterId).HasColumnName("REGISTER_ID");

                entity.Property(e => e.RequestObjectName)
                    .IsRequired()
                    .HasColumnName("REQUEST_OBJECT_NAME")
                    .HasMaxLength(500);

                entity.Property(e => e.RequestXslt).HasColumnName("REQUEST_XSLT");

                entity.Property(e => e.Resource)
                    .HasColumnName("RESOURCE")
                    .HasMaxLength(500);

                entity.Property(e => e.ResponseXslt).HasColumnName("RESPONSE_XSLT");
                entity.Property(e => e.MetadataXml).HasColumnName("METADATA_XML");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Register)
                    .WithMany(p => p.AdapterOperations)
                    .HasForeignKey(d => d.RegisterId)
                    .HasConstraintName("FK_dbo.ADAPTER_OPERATIONS_dbo.REGISTERS_REGISTER_ID");
            });

            modelBuilder.Entity<AuditExceptions>(entity =>
            {
                entity.ToTable("AUDIT_EXCEPTIONS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActionMethod)
                    .HasColumnName("ACTION_METHOD")
                    .HasMaxLength(200);

                entity.Property(e => e.AuthorityId).HasColumnName("AUTHORITY_ID");

                entity.Property(e => e.Controller)
                    .HasColumnName("CONTROLLER")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExceptionText)
                    .HasColumnName("EXCEPTION_TEXT")
                    .HasMaxLength(4000);

                entity.Property(e => e.ExceptionTime)
                    .HasColumnName("EXCEPTION_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Stacktrace).HasColumnName("STACKTRACE");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.AuditExceptions)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_dbo.AUDIT_EXCEPTIONS_dbo.AUTHORITIES_AUTHORITY_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuditExceptions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AUDIT_EXCEPTIONS_dbo.USERS_USER_ID");
            });

            modelBuilder.Entity<AuditReportExecutions>(entity =>
            {
                entity.ToTable("AUDIT_REPORT_EXECUTIONS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorityId).HasColumnName("AUTHORITY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReportExecutionTime)
                    .HasColumnName("REPORT_EXECUTION_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReportId).HasColumnName("REPORT_ID");

                entity.Property(e => e.RequestXml).HasColumnName("REQUEST_XML");

                entity.Property(e => e.ResponseXml).HasColumnName("RESPONSE_XML");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.ContextServiceURI).HasColumnName("CONTEXT_SERIVCE_URI");

                entity.Property(e => e.ContextServiceType).HasColumnName("CONTEXT_SERVICE_TYPE");
                
                entity.Property(e => e.ContextLawReason).HasColumnName("CONTEXT_LAW_REASON");

                entity.Property(e => e.CallContext).HasColumnName("CALL_CONTEXT");

                entity.Property(e => e.ContextEmployeeAdditionalId).HasColumnName("CONTEXT_EMPLOYEE_ADITIONAL_ID");

                entity.Property(e => e.ApiServiceCallId).HasColumnName("API_SERVICE_CALL_ID");

                entity.Property(e => e.HasError).HasColumnName("HAS_ERROR");

                entity.Property(e => e.RegisterErrorMessage).HasColumnName("REGISTER_ERROR_MESSAGE");

                entity.Property(e => e.RegisterErrorContent).HasColumnName("REGISTER_ERROR_CONTENT");

                entity.Property(e => e.UnhandledErrorMessage).HasColumnName("UNHANDLED_ERROR_MESSAGE");

                entity.Property(e => e.UnhandledErrorContent).HasColumnName("UNHANDLED_ERROR_CONTENT");

                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.AuditReportExecutions)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_dbo.AUDIT_REPORT_EXECUTIONS_dbo.AUTHORITIES_AUTHORITY_ID");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.AuditReportExecutions)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_dbo.AUDIT_REPORT_EXECUTIONS_dbo.REPORTS_REPORT_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuditReportExecutions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AUDIT_REPORT_EXECUTIONS_dbo.USERS_USER_ID");
            });

            modelBuilder.Entity<AuditSystemReportExecutions>(entity =>
            {
                entity.ToTable("AUDIT_SYSTEM_REPORT_EXECUTIONS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdapterOperationId).HasColumnName("ADAPTER_OPERATION_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExceptionMessage)
                    .HasColumnName("EXCEPTION_MESSAGE")
                    .HasMaxLength(2000);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequestXml).HasColumnName("REQUEST_XML");

                entity.Property(e => e.ResponseXml).HasColumnName("RESPONSE_XML");

                entity.Property(e => e.Stacktrace).HasColumnName("STACKTRACE");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.AuditSystemReportExecutions)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .HasConstraintName(
                        "FK_dbo.AUDIT_SYSTEM_REPORT_EXECUTIONS_dbo.ADAPTER_OPERATIONS_ADAPTER_OPERATION_ID");
            });

            modelBuilder.Entity<AuditTables>(entity =>
            {
                entity.ToTable("AUDIT_TABLES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("ACTION")
                    .HasMaxLength(50);

                entity.Property(e => e.AuthorityId).HasColumnName("AUTHORITY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.TableId).HasColumnName("TABLE_ID");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("TABLE_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.AuditTables)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_dbo.AUDIT_TABLES_dbo.AUTHORITIES_AUTHORITY_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuditTables)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AUDIT_TABLES_dbo.USERS_USER_ID");
            });

            modelBuilder.Entity<AuditUserActions>(entity =>
            {
                entity.ToTable("AUDIT_USER_ACTIONS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActionMethod)
                    .HasColumnName("ACTION_METHOD")
                    .HasMaxLength(200);

                entity.Property(e => e.AuthorityId).HasColumnName("AUTHORITY_ID");

                entity.Property(e => e.ChangedTables)
                    .HasColumnName("CHANGED_TABLES")
                    .HasMaxLength(400);

                entity.Property(e => e.Controller)
                    .HasColumnName("CONTROLLER")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExecuteStatus)
                    .HasColumnName("EXECUTE_STATUS")
                    .HasMaxLength(10);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Params)
                    .HasColumnName("PARAMS")
                    .HasMaxLength(4000);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(300);

                entity.Property(e => e.UserActionText)
                    .IsRequired()
                    .HasColumnName("USER_ACTION_TEXT")
                    .HasMaxLength(1000);

                entity.Property(e => e.UserActionTime)
                    .HasColumnName("USER_ACTION_TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserActionType)
                    .IsRequired()
                    .HasColumnName("USER_ACTION_TYPE")
                    .HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.AuditUserActions)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_dbo.AUDIT_USER_ACTIONS_dbo.AUTHORITIES_AUTHORITY_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuditUserActions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AUDIT_USER_ACTIONS_dbo.USERS_USER_ID");
            });

            modelBuilder.Entity<AuditValues>(entity =>
            {
                entity.ToTable("AUDIT_VALUES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuditTableId).HasColumnName("AUDIT_TABLE_ID");

                entity.Property(e => e.ColumnName)
                    .HasColumnName("COLUMN_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewValue)
                    .HasColumnName("NEW_VALUE")
                    .HasMaxLength(4000);

                entity.Property(e => e.OldValue)
                    .HasColumnName("OLD_VALUE")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.AuditTable)
                    .WithMany(p => p.AuditValues)
                    .HasForeignKey(d => d.AuditTableId)
                    .HasConstraintName("FK_dbo.AUDIT_VALUES_dbo.AUDIT_TABLES_AUDIT_TABLE_ID");
            });

            modelBuilder.Entity<Authorities>(entity =>
            {
                entity.ToTable("AUTHORITIES");

                entity.HasIndex(e => e.Acronym)
                    .HasName("UQ__AUTHORIT__AE1E985296BFCA8C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Acronym)
                    .HasColumnName("ACRONYM")
                    .HasMaxLength(100);

                entity.Property(e => e.CertificateStore).HasColumnName("CERTIFICATE_STORE");

                entity.Property(e => e.CertificateThumbprint)
                    .HasColumnName("CERTIFICATE_THUMBPRINT")
                    .HasMaxLength(200);

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("DISPLAY_NAME")
                    .HasMaxLength(200);

                entity.Property(e => e.IsMultitenantAuthority).HasColumnName("IS_MULTITENANT_AUTHORITY");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200);

                entity.Property(e => e.Oid)
                    .HasColumnName("OID")
                    .HasMaxLength(100);

                entity.Property(e => e.ParentAuthorityId).HasColumnName("PARENT_AUTHORITY_ID");

                entity.HasOne(d => d.ParentAuthority)
                    .WithMany(p => p.InverseParentAuthority)
                    .HasForeignKey(d => d.ParentAuthorityId)
                    .HasConstraintName("FK_dbo.AUTHORITIES_dbo.AUTHORITIES_PARENT_AUTHORITY_ID");
            });

            modelBuilder.Entity<EnumItems>(entity =>
            {
                entity.ToTable("ENUM_ITEMS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.EnumDisplayText)
                    .HasColumnName("ENUM_DISPLAY_TEXT")
                    .HasMaxLength(100);

                entity.Property(e => e.EnumValue)
                    .IsRequired()
                    .HasColumnName("ENUM_VALUE")
                    .HasMaxLength(100);

                entity.Property(e => e.IdentifierType).HasColumnName("IDENTIFIER_TYPE");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<EnumItemsToParameterTypes>(entity =>
            {
                entity.HasKey(e => new {e.EnumId, e.ParameterTypeId})
                    .HasName("PK_dbo.ENUM_ITEMS_TO_PARAMETER_TYPES");

                entity.ToTable("ENUM_ITEMS_TO_PARAMETER_TYPES");

                entity.Property(e => e.EnumId).HasColumnName("ENUM_ID");

                entity.Property(e => e.ParameterTypeId).HasColumnName("PARAMETER_TYPE_ID");

                entity.HasOne(d => d.Enum)
                    .WithMany(p => p.EnumItemsToParameterTypes)
                    .HasForeignKey(d => d.EnumId)
                    .HasConstraintName("FK_dbo.ENUM_ITEMS_TO_PARAMETER_TYPES_dbo.ENUM_ITEMS_ENUM_ID");

                entity.HasOne(d => d.ParameterType)
                    .WithMany(p => p.EnumItemsToParameterTypes)
                    .HasForeignKey(d => d.ParameterTypeId)
                    .HasConstraintName("FK_dbo.ENUM_ITEMS_TO_PARAMETER_TYPES_dbo.PARAMETER_TYPES_PARAMETER_TYPE_ID");
            });

            modelBuilder.Entity<FederationUsers>(entity =>
            {
                entity.ToTable("FEDERATION_USERS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("POSITION")
                    .HasMaxLength(200);

                entity.Property(e => e.UserAuthorityId).HasColumnName("USER_AUTHORITY_ID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.FederationUsers)
                    .HasForeignKey<FederationUsers>(d => d.Id)
                    //TODO: Check if this is OK
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.FEDERATION_USERS_dbo.USERS_ID");

                entity.HasOne(d => d.UserAuthority)
                    .WithMany(p => p.FederationUsers)
                    .HasForeignKey(d => d.UserAuthorityId)
                    .HasConstraintName("FK_dbo.FEDERATION_USERS_dbo.AUTHORITIES_USER_AUTHORITY_ID");
            });

            modelBuilder.Entity<LocalUsers>(entity =>
            {
                entity.ToTable("LOCAL_USERS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsPasswordMigrated).HasColumnName("IS_PASSWORD_MIGRATED");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.LocalUsers)
                    .HasForeignKey<LocalUsers>(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.LOCAL_USERS_dbo.FEDERATION_USERS_ID");
            });

            modelBuilder.Entity<UsersEauth>(entity =>
            {
                entity.ToTable("USERS_EAUTH");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("IDENTIFIER")
                    .HasMaxLength(50);

                entity.Property(e => e.IdentifierType)
                    .IsRequired()
                    .HasColumnName("IDENTIFIER_TYPE")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UsersEauth)
                    .HasForeignKey<UsersEauth>(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.USERS_EAUTH_dbo.FEDERATION_USERS_ID");
            });

            modelBuilder.Entity<ParameterTypes>(entity =>
            {
                entity.ToTable("PARAMETER_TYPES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("TYPE")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Parameters>(entity =>
            {
                entity.ToTable("PARAMETERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdentifierType).HasColumnName("IDENTIFIER_TYPE");

                entity.Property(e => e.IsRequired).HasColumnName("IS_REQUIRED");

                entity.Property(e => e.IsXmlElement).HasColumnName("IS_XML_ELEMENT");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Namespace)
                    .HasColumnName("NAMESPACE")
                    .HasMaxLength(500);

                entity.Property(e => e.OrderNumber).HasColumnName("ORDER_NUMBER");

                entity.Property(e => e.ParameterLabel)
                    .HasColumnName("PARAMETER_LABEL")
                    .HasMaxLength(200);

                entity.Property(e => e.ParameterName)
                    .IsRequired()
                    .HasColumnName("PARAMETER_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.ParameterTypeId).HasColumnName("PARAMETER_TYPE_ID");

                entity.Property(e => e.ParentParameterId).HasColumnName("PARENT_PARAMETER_ID");

                entity.Property(e => e.RegexExpression)
                    .HasColumnName("REGEX_EXPRESSION")
                    .HasMaxLength(200);

                entity.HasOne(d => d.ParameterType)
                    .WithMany(p => p.Parameters)
                    .HasForeignKey(d => d.ParameterTypeId)
                    .HasConstraintName("FK_dbo.PARAMETERS_dbo.PARAMETER_TYPES_PARAMETER_TYPE_ID");

                entity.HasOne(d => d.ParentParameter)
                    .WithMany(p => p.InverseParentParameter)
                    .HasForeignKey(d => d.ParentParameterId)
                    .HasConstraintName("FK_dbo.PARAMETERS_dbo.PARAMETERS_PARENT_PARAMETER_ID");
            });

            modelBuilder.Entity<ParametersToOperation>(entity =>
            {
                entity.HasKey(e => new {e.AdapterOperationId, e.ParameterId})
                    .HasName("PK_dbo.PARAMETERS_TO_OPERATION");

                entity.ToTable("PARAMETERS_TO_OPERATION");

                entity.Property(e => e.AdapterOperationId).HasColumnName("ADAPTER_OPERATION_ID");

                entity.Property(e => e.ParameterId).HasColumnName("PARAMETER_ID");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.ParametersToOperation)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .HasConstraintName("FK_dbo.PARAMETERS_TO_OPERATION_dbo.ADAPTER_OPERATIONS_ADAPTER_OPERATION_ID");

                entity.HasOne(d => d.Parameter)
                    .WithMany(p => p.ParametersToOperation)
                    .HasForeignKey(d => d.ParameterId)
                    .HasConstraintName("FK_dbo.PARAMETERS_TO_OPERATION_dbo.PARAMETERS_PARAMETER_ID");
            });

            modelBuilder.Entity<PublicUsers>(entity =>
            {
                entity.ToTable("PUBLIC_USERS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasColumnName("IDENTIFIER")
                    .HasMaxLength(200);

                entity.Property(e => e.PersonIdentifierType).HasColumnName("PERSON_IDENTIFIER_TYPE");

                entity.Property(e => e.TokenId)
                    .IsRequired()
                    .HasColumnName("TOKEN_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ValidFrom)
                    .HasColumnName("VALID_FROM")
                    .HasColumnType("datetime");

                entity.Property(e => e.ValidTo)
                    .HasColumnName("VALID_TO")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PublicUsers)
                    .HasForeignKey<PublicUsers>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_dbo.PUBLIC_USERS_dbo.USERS_ID");
            });

            modelBuilder.Entity<Registers>(entity =>
            {
                entity.ToTable("REGISTERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorityId).HasColumnName("AUTHORITY_ID");

                entity.Property(e => e.BindingName)
                    .HasColumnName("BINDING_NAME")
                    .HasMaxLength(200);

                entity.Property(e => e.ClientName)
                    .HasColumnName("CLIENT_NAME")
                    .HasMaxLength(200);

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(2000);

                entity.Property(e => e.Version)
                    .HasColumnName("VERSION")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.Registers)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_dbo.REGISTERS_dbo.AUTHORITIES_AUTHORITY_ID");
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.ToTable("REPORTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdapterOperationId).HasColumnName("ADAPTER_OPERATION_ID");

                entity.Property(e => e.AuthorityId).HasColumnName("AUTHORITY_ID");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.LawReason)
                    .HasColumnName("LAW_REASON")
                    .HasMaxLength(4000);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(2000);

                entity.Property(e => e.OrderNumber).HasColumnName("ORDER_NUMBER");

                entity.Property(e => e.ResponseXslt).HasColumnName("RESPONSE_XSLT");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.REPORTS_dbo.ADAPTER_OPERATIONS_ADAPTER_OPERATION_ID");

                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_dbo.REPORTS_dbo.AUTHORITIES_AUTHORITY_ID");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("ROLES");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__ROLES__D9C1FA00EDDD170E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorityId).HasColumnName("AUTHORITY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200);

                entity.Property(e => e.RoleType).HasColumnName("ROLE_TYPE");

                entity.HasOne(d => d.Authority)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.AuthorityId)
                    .HasConstraintName("FK_dbo.ROLES_dbo.AUTHORITIES_AUTHORITY_ID");
            });

            modelBuilder.Entity<RolesToReports>(entity =>
            {
                entity.ToTable("ROLES_TO_REPORTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReportId).HasColumnName("REPORT_ID");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.RolesToReports)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_dbo.ROLES_TO_REPORTS_dbo.REPORTS_REPORT_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesToReports)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.ROLES_TO_REPORTS_dbo.ROLES_ROLE_ID");
            });

            modelBuilder.Entity<UserEiks>(entity =>
            {
                entity.ToTable("USER_EIKS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eik)
                    .IsRequired()
                    .HasColumnName("EIK")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEiks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.USER_EIKS_dbo.PUBLIC_USERS_USER_ID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccessFailedCount).HasColumnName("ACCESS_FAILED_COUNT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.LockoutEndDate)
                    .HasColumnName("LOCKOUT_END_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.UserType).HasColumnName("USER_TYPE");
            });

            modelBuilder.Entity<UsersToRoles>(entity =>
            {
                entity.ToTable("USERS_TO_ROLES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersToRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.USERS_TO_ROLES_dbo.ROLES_ROLE_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersToRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.USERS_TO_ROLES_dbo.USERS_USER_ID");
            });

            modelBuilder.Entity<UsersFavouriteReports>(entity =>
            {
                entity.ToTable("USERS_FAVOURITE_REPORTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReportId).HasColumnName("REPORT_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersFavouriteReports)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.USERS_FAVOURITE_REPORTS_dbo.USERS_USER_ID");
            });

            modelBuilder.Entity<UsersToReports>(entity =>
            {
                entity.ToTable("USERS_TO_REPORTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("MODIFIED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReportId).HasColumnName("REPORT_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersToReports)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.USERS_TO_REPORTS_dbo.USERS_USER_ID");
            });


            modelBuilder.Entity<ReportsForUsersView>(entity =>
            {
                entity.HasKey(e => e.OperationId);

                entity.ToTable("REPORTS_FOR_USERS_VIEW");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.AuthorityId).HasColumnName("AUTHORITY_ID");
                entity.Property(e => e.AuthorityName).HasColumnName("AUTHORITY_NAME");
                entity.Property(e => e.AuthorityAcronym).HasColumnName("AUTHORITY_ACRONYM");
                entity.Property(e => e.RegisterId).HasColumnName("REGISTER_ID");
                entity.Property(e => e.RegisterName).HasColumnName("REGISTER_NAME");
                entity.Property(e => e.OperationId).HasColumnName("OPERATION_ID");
                entity.Property(e => e.OperationName).HasColumnName("OPERATION_NAME");
                entity.Property(e => e.ReportId).HasColumnName("REPORT_ID");
                entity.Property(e => e.ReportName).HasColumnName("REPORT_NAME");
                entity.Property(e => e.Favourite).HasColumnName("FAVOURITE");
                entity.Property(e => e.UserId).HasColumnName("USER_ID");
            });


            modelBuilder.Entity<ClearFavouriteReportsOutput>(entity =>
            {
                entity.HasKey(e => new {e.UserId, e.ReportId});

                entity.Property(e => e.ReportId)
                    .HasColumnName("REPORT_ID");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID");
            });


            modelBuilder.Entity<AsyncReportExecutions>(entity =>
            {
                entity.ToTable("ASYNC_REPORT_EXECUTION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApiServiceCallId)
                    .IsRequired()
                    .HasColumnName("API_SERVICECALL_ID");

                entity.Property(e => e.VerificationCode)
                    .IsRequired()
                    .HasColumnName("VERIFICATION_CODE")
                    .HasMaxLength(400);

                entity.Property(e => e.AdapterOperationId)
                    .IsRequired()
                    .HasColumnName("ADAPTER_OPERATION_ID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.SubmittedOn)
                    .IsRequired()
                    .HasColumnName("SUBMITTED_ON");

                entity.Property(e => e.ReceivedOn)
                    .HasColumnName("RECEIVED_ON");

                entity.Property(e => e.Result)
                    .HasColumnName("RESULT");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.AsyncReportExecutions)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .HasConstraintName(
                        "FK_dbo.ASYNC_REPORT_EXECUTION_dbo.ADAPTER_OPERATIONS_ADAPTER_OPERATION_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AsyncReportExecutions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName(
                        "FK_dbo.ASYNC_REPORT_EXECUTION_dbo.USERS_USER_ID");

            });

        }
    }
}