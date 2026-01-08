using Microsoft.EntityFrameworkCore;
using OrionOps.Domain.Entities;

namespace OrionOps.Infrastructure.Data
{
    public class OrionOpsDbContext : DbContext
    {
        public OrionOpsDbContext(DbContextOptions<OrionOpsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tenant> Tenants => Set<Tenant>();
    }
}
