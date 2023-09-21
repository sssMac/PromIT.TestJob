using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PromIT.TestJob.Persistence
{
    public class ReviewDbContextFactory : IDesignTimeDbContextFactory<ReviewsDbContext>
    {
        public ReviewsDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ReviewsDbContext>();
            var connectionString = configuration.GetConnectionString("ReviewsDbConnectionString");

            builder.UseNpgsql(connectionString);

            return new ReviewsDbContext(builder.Options);
        }
    }
}
