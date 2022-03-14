using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegiX.Info.Infrastructure.Models
{
    public partial class RegiXContext : DbContext
    {
        public RegiXContext()
        {
        }

        public RegiXContext(DbContextOptions<RegiXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrations> Administrations { get; set; }
        public virtual DbSet<AdapterOperations> AdapterOperations { get; set; }
        public virtual DbSet<ApiServiceConsumers> ApiServiceConsumers { get; set; }
        public virtual DbSet<CertificateConsumerRole> CertificateConsumerRole { get; set; }
        public virtual DbSet<CertificateElementAccess> CertificateElementAccess { get; set; }
        public virtual DbSet<CertificateOperationAccess> CertificateOperationAccess { get; set; }
        public virtual DbSet<ConsumerAccessRequests> ConsumerAccessRequests { get; set; }
        public virtual DbSet<ConsumerAccessRequestsStatus> ConsumerAccessRequestsStatus { get; set; }
        public virtual DbSet<ConsumerCertificates> ConsumerCertificates { get; set; }
        public virtual DbSet<ConsumerProfileStatus> ConsumerProfileStatus { get; set; }
        public virtual DbSet<ConsumerProfileUsers> ConsumerProfileUsers { get; set; }
        public virtual DbSet<ConsumerProfiles> ConsumerProfiles { get; set; }
        public virtual DbSet<ConsumerRequestElements> ConsumerRequestElements { get; set; }
        public virtual DbSet<ConsumerRequestStatus> ConsumerRequestStatus { get; set; }
        public virtual DbSet<ConsumerRequests> ConsumerRequests { get; set; }
        public virtual DbSet<ConsumerRoles> ConsumerRoles { get; set; }
        public virtual DbSet<ConsumerSystemCertificates> ConsumerSystemCertificates { get; set; }
        public virtual DbSet<ConsumerSystems> ConsumerSystems { get; set; }
        public virtual DbSet<RegisterObjectElements> RegisterObjectElements { get; set; }
        public virtual DbSet<Registers> Registers { get; set; }
        public virtual DbSet<Statistics> Statistics { get; set; }
        public virtual DbSet<MonthlyStatistics> MonthlyStatistics { get; set; }

        public virtual DbSet<ConsumerRequestOperationDb> ConsumerRequestOperationDb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

                entity.Property(e => e.Oid)
                    .HasColumnName("OID")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.Administration)
                    .WithMany(p => p.ApiServiceConsumers)
                    .HasForeignKey(d => d.AdministrationId)
                    .HasConstraintName("FK_API_SERVICE_CONSUMERS_ADMINISTRATIONS");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_CONSUMER_ROLE_CONSUMER_CERTIFICATES");

                entity.HasOne(d => d.ConsumerRole)
                    .WithMany(p => p.CertificateConsumerRole)
                    .HasForeignKey(d => d.ConsumerRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_CONSUMER_ROLE_CONSUMER_ROLES");
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

                entity.HasOne(d => d.ConsumerCertificate)
                    .WithMany(p => p.CertificateOperationAccess)
                    .HasForeignKey(d => d.ConsumerCertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CERTIFICATE_OPERATON_ACCESS");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.CertificateOperationAccess)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATON_CERTIFICATE_ACCESS");
            });

            modelBuilder.Entity<ConsumerAccessRequests>(entity =>
            {
                entity.HasKey(e => e.ConsumerAccessRequestId);

                entity.ToTable("CONSUMER_ACCESS_REQUESTS");

                entity.Property(e => e.ConsumerAccessRequestId)
                    .HasColumnName("CONSUMER_ACCESS_REQUEST_ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdapterOperationId)
                    .HasColumnName("ADAPTER_OPERATION_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ConsumerRequestId)
                    .HasColumnName("CONSUMER_REQUEST_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.ConsumerSystemCertificateId)
                    .HasColumnName("CONSUMER_SYSTEM_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.LawReason)
                    .HasColumnName("LAW_REASON")
                    .HasMaxLength(500);

                entity.Property(e => e.RelatedServices).HasColumnName("RELATED_SERVICES");

                entity.Property(e => e.RelatedServicesCode).HasColumnName("RELATED_SERVICES_CODE");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.HasOne(d => d.ConsumerRequest)
                    .WithMany(p => p.ConsumerAccessRequests)
                    .HasForeignKey(d => d.ConsumerRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_ACCESS_REQUESTS_CONSUMER_REQUESTS");

                entity.HasOne(d => d.ConsumerSystemCertificate)
                    .WithMany(p => p.ConsumerAccessRequests)
                    .HasForeignKey(d => d.ConsumerSystemCertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_ACCESS_REQUESTS_CONSUMER_SYSTEM_CERTIFICATES");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.ConsumerAccessRequests)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONSUMER_ACCESS_REQUESTS_ADAPTER_OPERATIONS");
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
                    .HasDefaultValueSql("((1))")
                    .HasComment("Активен");

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
                    .HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

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

            modelBuilder.Entity<ConsumerProfileStatus>(entity =>
            {
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

                entity.Property(e => e.ConsumerProfileUserId)
                    .HasColumnName("CONSUMER_PROFILE_USER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccessFailedCount).HasColumnName("ACCESS_FAILED_COUNT");

                entity.Property(e => e.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");

                entity.Property(e => e.ConsumerProfileId)
                    .HasColumnName("CONSUMER_PROFILE_ID")
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

                entity.Property(e => e.NormalizedUsername).HasColumnName("NORMALIZED_USERNAME");

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

                entity.Property(e => e.Username).HasColumnName("USERNAME");

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

            modelBuilder.Entity<ConsumerRequestStatus>(entity =>
            {
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
                entity.HasKey(e => e.Id);

                entity.ToTable("CONSUMER_REQUESTS");

                entity.Property(e => e.Id)
                    .HasColumnName("CONSUMER_REQUEST_ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

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

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(200);

                entity.Property(e => e.OutDocumentNumber)
                    .HasColumnName("OUT_DOCUMENT_NUMBER")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("STATUS");

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

            modelBuilder.Entity<ConsumerRoles>(entity =>
            {
                entity.HasKey(e => e.ConsumerRoleId);

                entity.ToTable("CONSUMER_ROLES");

                entity.Property(e => e.ConsumerRoleId)
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

            modelBuilder.Entity<ConsumerSystemCertificates>(entity =>
            {
                entity.HasKey(e => e.ConsumerSystemCertificateId);

                entity.ToTable("CONSUMER_SYSTEM_CERTIFICATES");

                entity.Property(e => e.ConsumerSystemCertificateId)
                    .HasColumnName("CONSUMER_SYSTEM_CERTIFICATE_ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

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
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

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

                entity.Property(e => e.Contract)
                    .IsRequired()
                    .HasColumnName("CONTRACT")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Contract");

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
                    .HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

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

                entity.Property(e => e.Xslt).HasColumnName("XSLT");

                entity.HasOne(d => d.RegisterAdapter)
                    .WithMany(p => p.RegisterObjects)
                    .HasForeignKey(d => d.RegisterAdapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGISTER_OBJECT_ADAPTER");
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

                entity.HasOne(d => d.Administration)
                    .WithMany(p => p.Registers)
                    .HasForeignKey(d => d.AdministrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REGISTER_ADMINISTRATION");
            });

            modelBuilder.Entity<Statistics>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Code)
                    .HasColumnName("Code");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("DateFrom");

                entity.Property(e => e.DateTo)
                    .HasColumnName("DateTo");

                entity.Property(e => e.Records)
                    .HasColumnName("Records");
            });

            modelBuilder.Entity<MonthlyStatistics>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Count)
                    .HasColumnName("Count");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
