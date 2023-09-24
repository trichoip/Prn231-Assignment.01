using EStore.Repositories;
using EStore.Share.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository repository;

        public MemberController(IMemberRepository _repository)
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
        public async Task<IActionResult> CreateAsync(MemberDTO product)
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

        public async Task<IActionResult> UpdateAsync(int id, MemberDTO productRespond)
        {
            var pTmp = await repository.FindByIdAsync(id);
            if (pTmp == null)
            {
                return NotFound();
            }
            return Ok(await repository.UpdateAsync(productRespond).ConfigureAwait(false));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            if (await repository.LoginAsync(request.Email, request.Password) is not { } meber) return BadRequest();

            return Ok(meber);
        }
    }
}
