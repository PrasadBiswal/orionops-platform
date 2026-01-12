using OrionOps.Domain.Entities;

namespace OrionOps.Application.Interfaces
{
    public interface ITenantRepository
    {
        Task<IEnumerable<Tenant>> GetAllAsync();
        Task<Tenant?> GetByIdAsync(Guid id);
        Task AddAsync(Tenant tenant);
    }
}
