using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegiX.IdentityServer
{
    public partial class RegiXAdminContext : DbContext
    {
        public RegiXAdminContext()
        {
        }

        public RegiXAdminContext(DbContextOptions<RegiXAdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrations> Administrations { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersEAuth> UsersEAuth { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new ApplicationException("RegiXAdminContext is not configured!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrations>(entity =>
            {
                entity.HasKey(e => e.AdministrationId);

                entity.ToTable("ADMINISTRATIONS");

                entity.Property(e => e.AdministrationId)
                    .HasColumnName("ADMINISTRATION_ID")
                    .HasColumnType("numeric(20, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Acronym)
                    .HasColumnName("ACRONYM")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdministrationTypeId)
                    .HasColumnName("ADMINISTRATION_TYPE_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Depth).HasColumnName("DEPTH");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
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
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.ParentAuthority)
                    .WithMany(p => p.InverseParentAuthority)
                    .HasForeignKey(d => d.ParentAuthorityId)
                    .HasConstraintName("FK_ADMINISTRATIONS_ADMINISTRATIONS");
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
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.AdministrationId)
                    .HasColumnName("ADMINISTRATION_ID")
                    .HasColumnType("numeric(20, 0)");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FailedPswdAnsAtmpCount)
                    .HasColumnName("FAILED_PSWD_ANS_ATMP_COUNT")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.FailedPswdAnsAtmpWdwStart)
                    .HasColumnName("FAILED_PSWD_ANS_ATMP_WDW_START")
                    .HasColumnType("datetime");

                entity.Property(e => e.FailedPswdAtmpCount)
                    .HasColumnName("FAILED_PSWD_ATMP_COUNT")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.FailedPswdAtmpWdwStart)
                    .HasColumnName("FAILED_PSWD_ATMP_WDW_START")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsAdmin).HasColumnName("IS_ADMIN");

                entity.Property(e => e.IsAnonymous).HasColumnName("IS_ANONYMOUS");

                entity.Property(e => e.IsApproved).HasColumnName("IS_APPROVED");

                entity.Property(e => e.IsLockedOut).HasColumnName("IS_LOCKED_OUT");

                entity.Property(e => e.LastActivityDate)
                    .HasColumnName("LAST_ACTIVITY_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastLockoutDate)
                    .HasColumnName("LAST_LOCKOUT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnName("LAST_LOGIN_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangedDate)
                    .HasColumnName("LAST_PASSWORD_CHANGED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordAnswer)
                    .HasColumnName("PASSWORD_ANSWER")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordQuestion)
                    .HasColumnName("PASSWORD_QUESTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

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
                    .HasDefaultValueSql("([dbo].[getUsernameByUserId](CONVERT([numeric](20,0),CONVERT([varbinary](13),context_info()))))");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.UserComment)
                    .HasColumnName("USER_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

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
                    .HasColumnType("numeric(20, 0)")
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
        }
    }
}
