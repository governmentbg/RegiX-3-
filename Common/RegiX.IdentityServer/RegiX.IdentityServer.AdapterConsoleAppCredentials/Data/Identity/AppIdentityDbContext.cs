using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Infrastructure.Data.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("AspNetUsers");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserName).HasColumnName("UserName");

                entity.Property(e => e.NormalizedUserName).HasColumnName("NormalizedUserName");

                entity.Property(e => e.Email).HasColumnName("Email");

                entity.Property(e => e.NormalizedEmail).HasColumnName("NormalizedEmail");

                entity.Property(e => e.EmailConfirmed).HasColumnName("EmailConfirmed");

                entity.Property(e => e.PasswordHash).HasColumnName("PasswordHash");

                entity.Property(e => e.SecurityStamp).HasColumnName("SecurityStamp");

                entity.Property(e => e.ConcurrencyStamp).HasColumnName("ConcurrencyStamp");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");

                entity.Property(e => e.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");

                entity.Property(e => e.LockoutEnd).HasColumnName("LockoutEnd");

                entity.Property(e => e.LockoutEnabled).HasColumnName("LockoutEnabled");

                entity.Property(e => e.AccessFailedCount).HasColumnName("AccessFailedCount");

                entity.Property(e => e.Name).HasColumnName("Name");

                entity.Property(e => e.IsActive).HasColumnName("IsActive");
            });
        }

       
    }
}
