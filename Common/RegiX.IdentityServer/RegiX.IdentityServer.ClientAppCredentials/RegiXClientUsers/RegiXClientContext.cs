using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegiX.IdentityServer.RegiXClientUsers
{
    public partial class RegiXClientContext : DbContext
    {
        public RegiXClientContext()
        {
        }

        public RegiXClientContext(DbContextOptions<RegiXClientContext> options)
            : base(options)
        {
        }

        public RegiXClientContext(string placeholder, DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<FederationUsers> FederationUsers { get; set; }
        public virtual DbSet<LocalUsers> LocalUsers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersToRoles> UsersToRoles { get; set; }
        public virtual DbSet<UsersEAuth> UsersEAuth { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Administrations> Administrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new ApplicationException("RegiXClientContext is not configured!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.FEDERATION_USERS_dbo.USERS_ID");
            });

            modelBuilder.Entity<UsersEAuth>(entity =>
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
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UserEAuth)
                    .HasForeignKey<UsersEAuth>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.USERS_EAUTH_dbo.FEDERATION_USERS_ID");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LOCAL_USERS_dbo.FEDERATION_USERS_ID");
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

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200);

                entity.Property(e => e.PswdVerificationToken)
                    .HasColumnName("PSWD_VERIFICATION_TOKEN")
                    .HasMaxLength(128);

                entity.Property(e => e.PswdVerTokenExpirationDate)
                    .HasColumnName("PSWD_VER_TOKEN_EXPIRATION_DATE")
                    .HasColumnType("datetime");

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
            });

            modelBuilder.Entity<Administrations>(entity =>
            {
                entity.ToTable("AUTHORITIES");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(200);
            });
        }
    }

    public class RegiXClientCitizensContext : RegiXClientContext
    {
        public RegiXClientCitizensContext(DbContextOptions<RegiXClientCitizensContext> options)
            : base(string.Empty, options)
        {
        }
    }
}
