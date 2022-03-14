using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TechnoLogica.RegiX.AdapterConsole.Infrastructure.Models
{
    public partial class RegiXAdapterConsoleContext : DbContext
    {
        public RegiXAdapterConsoleContext()
        {
        }

        public RegiXAdapterConsoleContext(DbContextOptions<RegiXAdapterConsoleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdapterOperations> AdapterOperations { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<IdentityRole> IdentityRole { get; set; }
        public virtual DbSet<OperationCalls> OperationCalls { get; set; }
        public virtual DbSet<OperationsPersistance> OperationsPersistance { get; set; }
        public virtual DbSet<OperationsToRoles> OperationsToRoles { get; set; }
        public virtual DbSet<ReturnedCalls> ReturnedCalls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=RegiXAdapterConsoleNew;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
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

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.OperationCalls)
                    .HasForeignKey(d => d.AssignedTo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.OPERATION_CALLS_dbo.USERS_ID");
            });

            modelBuilder.Entity<OperationsPersistance>(entity =>
            {
                entity.ToTable("OPERATIONS_PERSISTANCE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Acknowledged).HasColumnName("ACKNOWLEDGED");

                entity.Property(e => e.AdapterOperationId).HasColumnName("ADAPTER_OPERATION_ID");

                entity.Property(e => e.ApiServiceCallId).HasColumnName("API_SERVICE_CALL_ID");

                entity.Property(e => e.CallbackUrl)
                    .HasColumnName("CALLBACK_URL")
                    .HasMaxLength(1000);

                entity.Property(e => e.NextRetry)
                    .HasColumnName("NEXT_RETRY")
                    .HasColumnType("date");

                entity.Property(e => e.RawRequest).HasColumnName("RAW_REQUEST");

                entity.Property(e => e.RawResult).HasColumnName("RAW_RESULT");

                entity.Property(e => e.RawUnsignedResult).HasColumnName("RAW_UNSIGNED_RESULT");

                entity.Property(e => e.RetryCount).HasColumnName("RETRY_COUNT");

                entity.Property(e => e.VerificationCode)
                    .IsRequired()
                    .HasColumnName("VERIFICATION_CODE")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.OperationsPersistance)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.OPERATIONS_PERSISTANCE_dbo.ADAPTER_OPERATION_ID");
            });

            modelBuilder.Entity<OperationsToRoles>(entity =>
            {
                entity.ToTable("OPERATIONS_TO_ROLES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdapterOperationId).HasColumnName("ADAPTER_OPERATION_ID");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.HasOne(d => d.AdapterOperation)
                    .WithMany(p => p.OperationsToRoles)
                    .HasForeignKey(d => d.AdapterOperationId)
                    .HasConstraintName("FK_dbo.OPERATIONS_TO_ROLES_dbo.ADAPTER_OPERATIONS_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.OperationsToRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.OPERATIONS_TO_ROLES_dbo.AspNetRoles_Id");
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

                entity.HasOne(d => d.ReturnedByNavigation)
                    .WithMany(p => p.ReturnedCalls)
                    .HasForeignKey(d => d.ReturnedBy)
                    .HasConstraintName("FK_dbo.RETURNED_CALLS_dbo.USERS_ID");
            });

            modelBuilder
                .Query<OperationsToUsers>()
                .ToView("OPERATIONS_TO_USERS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
