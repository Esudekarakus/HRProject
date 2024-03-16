using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Persistence.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
 
        public DbSet<Employer> Employers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Roller
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "adminRoleId",
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "employerRoleId",
                    Name = "employer",
                    NormalizedName = "EMPLOYER"
                },
                new IdentityRole
                {
                    Id = "employeeRoleId",
                    Name = "employee",
                    NormalizedName = "EMPLOYEE"
                }
            );

            // Kullanıcılar
            var hasher = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = "adminUserId",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@boost.com",
                    NormalizedEmail = "ADMIN@BOOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin123+"),
                    SecurityStamp = string.Empty,
                    FirstName = "Admin",
                    LastName = "Admin"
                },
                new AppUser
                {
                    Id = "employerUserId",
                    UserName = "employer",
                    NormalizedUserName = "EMPLOYER",
                    Email = "employer@boost.com",
                    NormalizedEmail = "EMPLOYER@BOOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Employer123+"),
                    SecurityStamp = string.Empty,
                    FirstName = "Employer",
                    LastName = "Employer"
                },
                new AppUser
                {
                    Id = "employeeUserId",
                    UserName = "employee",
                    NormalizedUserName = "EMPLOYEE",
                    Email = "employee@boost.com",
                    NormalizedEmail = "EMPLOYEE@BOOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Employee123+"),
                    SecurityStamp = string.Empty,
                    FirstName = "Employee",
                    LastName = "Employee"
                }
            );

            // Roller ve kullanıcılar ilişkilendirilme
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "adminUserId",
                    RoleId = "adminRoleId"
                },
                new IdentityUserRole<string>
                {
                    UserId = "employerUserId",
                    RoleId = "employerRoleId"
                },
                new IdentityUserRole<string>
                {
                    UserId = "employeeUserId",
                    RoleId = "employeeRoleId"
                }
            );
        }

    }
}
