using EStore.Repositories;
using EStore.Share.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository repository;

        public CategoryController(ICategoryRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public async Task<IActionResult> FindAllAsync()
        {
            return Ok(await repository.FindAllAsync().ConfigureAwait(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            return Ok(await repository.FindByIdAsync(id).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryDTO product)
        {
            return Ok(await repository.CreateAsync(product).ConfigureAwait(false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entity = await repository.FindByIdAsync(id);

            await repository.DeleteAsync(entity).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, CategoryDTO productRespond)
        {
            var pTmp = await repository.FindByIdAsync(id);
            if (pTmp == null)
            {
                return NotFound();
            }
            return Ok(await repository.UpdateAsync(pTmp).ConfigureAwait(false));
        }
    }
}
