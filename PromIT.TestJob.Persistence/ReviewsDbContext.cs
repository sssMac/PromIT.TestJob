using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PromIT.TestJob.Domain;
using PromIT.TestJob.Persistence.Configuration.Tables;

namespace PromIT.TestJob.Persistence
{
    public class ReviewsDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ReviewsDbContext(DbContextOptions<ReviewsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            TablesConfiguration.Configure(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReviewsDbContext).Assembly);
        }
    }
}
