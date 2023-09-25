using EStore.Repositories;
using EStore.Share.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public async Task<IActionResult> FindAllAsync(string? search)
        {
            return Ok(await repository.FindAllAsync().ConfigureAwait(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            return Ok(await repository.FindByIdAsync(id).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductDTO product)
        {
            return Ok(await repository.CreateAsync(product).ConfigureAwait(false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var p = await repository.FindByIdAsync(id).ConfigureAwait(false);
            if (p == null)
            {
                return NotFound();
            }
            await repository.DeleteAsync(p).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ProductDTO productRespond)
        {
            var pTmp = await repository.FindByIdAsync(id);
            if (pTmp == null)
            {
                return NotFound();
            }
            return Ok(await repository.UpdateAsync(productRespond).ConfigureAwait(false));
        }

    }
}
