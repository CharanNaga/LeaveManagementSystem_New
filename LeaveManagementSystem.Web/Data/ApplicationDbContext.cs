using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "215FCB49-0B60-447E-850A-A15CCACF987D",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },

                new IdentityRole
                {
                    Id = "D4A791BF-5E5E-4C50-9349-81B267418952",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                },

                new IdentityRole
                {
                    Id = "FDEB3D96-C44B-49D7-A33D-93487FADE4F5",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(

                new IdentityUser
                {
                    Id = "C8E52E08-1D08-44DF-AE74-10E26E1B39E9",
                    Email = "admin@domain.com",
                    NormalizedEmail = "ADMIN@DOMAIN.COM",
                    UserName = "admin@domain.com",
                    NormalizedUserName = "ADMIN@DOMAIN.COM",
                    PasswordHash = hasher.HashPassword(null,"a@min"),
                    EmailConfirmed = true
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "FDEB3D96-C44B-49D7-A33D-93487FADE4F5",
                    UserId = "C8E52E08-1D08-44DF-AE74-10E26E1B39E9",
                });
        }
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
