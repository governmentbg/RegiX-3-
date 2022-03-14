using Microsoft.EntityFrameworkCore;

namespace RegiX.IdentityServer.ConsumerProfileCredentials.Context
{
    public partial class ConsumerProfilesContext : DbContext
    {
        public ConsumerProfilesContext()
        {
        }

        public ConsumerProfilesContext(DbContextOptions<ConsumerProfilesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConsumerProfileStatus> ConsumerProfileStatus { get; set; }
        public virtual DbSet<ConsumerProfileUsers> ConsumerProfileUsers { get; set; }
        public virtual DbSet<ConsumerProfiles> ConsumerProfiles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                entity.HasKey(e => e.Id);

                entity.ToTable("CONSUMER_PROFILE_USERS");

                entity.Property(e => e.AccessFailedCount).HasColumnName("ACCESS_FAILED_COUNT");

                entity.Property(e => e.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");

                entity.Property(e => e.ConsumerProfileId)
                    .HasColumnName("CONSUMER_PROFILE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Id)
                    .HasColumnName("CONSUMER_PROFILE_USER_ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();


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

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedUserName)
                .HasColumnName("NORMALIZED_USERNAME")
                    .HasMaxLength(256);

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
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AcceptedEula).HasColumnName("ACCEPTED_EULA");

                entity.Property(e => e.AdministrationId)
                    .HasColumnName("ADMINISTRATION_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.DocumentNumber)
                    .HasColumnName("DOCUMENT_NUMBER")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
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

                //entity.HasOne(d => d.Administration)
                //    .WithMany(p => p.Users)
                //    .HasForeignKey(d => d.AdministrationId)
                //    .HasConstraintName("FK_USER_ADMINISTRATION");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
