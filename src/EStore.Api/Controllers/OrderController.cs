using EStore.Repositories;
using EStore.Share.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository repository;

        public OrderController(IOrderRepository _repository)
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
        public async Task<IActionResult> CreateAsync(OrderDTO product)
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

        public async Task<IActionResult> UpdateAsync(int id, OrderDTO productRespond)
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
