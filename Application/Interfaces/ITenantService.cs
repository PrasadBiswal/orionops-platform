using OrionOps.Domain.Entities;

namespace OrionOps.Application.Interfaces
{
    public interface ITenantService
    {
        Task<IEnumerable<Tenant>> GetAllAsync();
        Task<Tenant?> GetByIdAsync(Guid id);
        Task CreateAsync(string name);
    }
}
