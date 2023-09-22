using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromIT.TestJob.Application.Consts;


namespace PromIT.TestJob.Persistence.Configuration.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {

        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var admin = new IdentityUser
            {
                Id = "8a8670b4-afb9-4734-a596-ffc3d2156e50",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "admin");

            builder.HasData(admin);
        }

    }

    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "8a8670b4-afb9-4734-a596-ffc3d2156e50",
                    RoleId = "03476e34-e1eb-49e1-8eaf-73ec2424415e",
                });
        }

    }
}
