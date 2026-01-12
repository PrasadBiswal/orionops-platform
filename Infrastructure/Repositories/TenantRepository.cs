using Microsoft.EntityFrameworkCore;
using OrionOps.Application.Interfaces;
using OrionOps.Domain.Entities;
using OrionOps.Infrastructure.Data;

namespace OrionOps.Infrastructure.Repositories
{
	public class TenantRepository : ITenantRepository
	{
		private readonly OrionOpsDbContext _context;

		public TenantRepository(OrionOpsDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Tenant>> GetAllAsync()
		{
			return await _context.Tenants
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<Tenant?> GetByIdAsync(Guid id)
		{
			return await _context.Tenants
				.AsNoTracking()
				.FirstOrDefaultAsync(t => t.Id == id);
		}

		public async Task AddAsync(Tenant tenant)
		{
			_context.Tenants.Add(tenant);
			await _context.SaveChangesAsync();
		}
	}
}
