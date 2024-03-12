using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Persistence.Identity.SeedData
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var hasher = new PasswordHasher<AppUser>();

            builder.HasData(new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@contoso.com",
                NormalizedEmail = "ADMIN@BOOST.COM",
                PasswordHash = hasher.HashPassword(null, "Admin123+"),
                SecurityStamp = string.Empty,
                FirstName = "Admin",
                LastName = "Admin"
            });

            builder.HasData(new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "employer",
                NormalizedUserName = "EMPLOYER",
                Email = "employer@contoso.com",
                NormalizedEmail = "EMPLOYER@BOOST.COM",
                PasswordHash = hasher.HashPassword(null, "Employer123+"),
                SecurityStamp = string.Empty,
                FirstName = "Employer",
                LastName = "Employer"
            });

            builder.HasData(new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "employee",
                NormalizedUserName = "EMPLOYEE",
                Email = "employee@contoso.com",
                NormalizedEmail = "EMPLOYEE@BOOST.COM",
                PasswordHash = hasher.HashPassword(null, "Employee123+"),
                SecurityStamp = string.Empty,
                FirstName = "Employee",
                LastName = "Employee"
            });
        }
    }
}
