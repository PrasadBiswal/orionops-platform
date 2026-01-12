using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace OrionOps.Infrastructure.Data
{
    public class OrionOpsDbContextFactory
        : IDesignTimeDbContextFactory<OrionOpsDbContext>
    {
        public OrionOpsDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<OrionOpsDbContext>();
            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));

            return new OrionOpsDbContext(optionsBuilder.Options);
        }
    }
}
