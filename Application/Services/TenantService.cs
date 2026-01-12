using OrionOps.Application.Interfaces;
using OrionOps.Domain.Entities;

namespace OrionOps.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _repository;

        public TenantService(ITenantRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Tenant?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(string name)
        {
            // Business rule: tenant name must exist
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tenant name is required");

            var tenant = new Tenant
            {
                Id = Guid.NewGuid(),
                Name = name,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(tenant);
        }
    }
}
