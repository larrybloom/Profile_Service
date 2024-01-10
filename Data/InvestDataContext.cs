using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProfileService.Entities;
using ProfileService.Data.DTOs;

namespace ProfileService.Data
{
    public class InvestDataContext : IdentityDbContext<AppUser>
    {
        public InvestDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Privileges> Privileges { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<RevokeToken> RevokeTokens { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<OrganizationRoles> OrganizationRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-one relationship between OrganizationRoles and Organization
            modelBuilder.Entity<OrganizationRoles>()
                .HasOne(o => o.Organization)
                .WithOne(or => or.OrganizationRoles)
                .HasForeignKey<OrganizationRoles>(or => or.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired cascade behavior, in this case, restrict

            // Configure one-to-one relationship between Roles and OrganizationRoles
            modelBuilder.Entity<Roles>()
                .HasOne(r => r.OrganizationRoles)
                .WithOne(or => or.Roles)
                .HasForeignKey<OrganizationRoles>(or => or.RolesId)
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired cascade behavior, in this case, restrict

            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithOne(u => u.RefreshToken)
                .HasForeignKey<RefreshToken>(rt => rt.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired cascade behavior, in this case, restrict

            modelBuilder.Entity<RevokeToken>()
                .HasOne(rt => rt.User)
                .WithOne(u => u.RevokeToken)
                .HasForeignKey<RevokeToken>(rt => rt.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired cascade behavior, in this case, restrict
        }
//public DbSet<ProfileService.Data.DTOs.userDTO> userDTO { get; set; } = default!;




    }
}
