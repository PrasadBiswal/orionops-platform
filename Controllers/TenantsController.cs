using Microsoft.AspNetCore.Mvc;
using OrionOps.Application.Interfaces;

namespace OrionOps.Api.Controllers
{
    [ApiController]
    [Route("api/tenants")]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantsController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tenants = await _tenantService.GetAllAsync();
            return Ok(tenants);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string name)
        {
            await _tenantService.CreateAsync(name);
            return CreatedAtAction(nameof(GetAll), null);
        }
    }
}
