using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromIT.TestJob.Application;
using PromIT.TestJob.Application.Consts;

namespace PromIT.TestJob.Persistence.Configuration.Entities
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = Roles.Admin,
                    NormalizedName = Roles.Admin.ToUpper()
                },
                new IdentityRole
                {
                    Name = Roles.Basic,
                    NormalizedName = Roles.Basic.ToUpper()
                }
                );
        }
    }
}
