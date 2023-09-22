using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromIT.TestJob.Application;
using PromIT.TestJob.Application.Consts;

namespace PromIT.TestJob.Persistence.Configuration.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "03476e34-e1eb-49e1-8eaf-73ec2424415e",
                    Name = Roles.Admin,
                    NormalizedName = Roles.Admin.ToUpper()
                },
                new IdentityRole
                {
                    Id = "3b87c435-a7e9-4165-9eb4-4068f652d39b",
                    Name = Roles.Basic,
                    NormalizedName = Roles.Basic.ToUpper()
                }
                );
        }
    }
}
