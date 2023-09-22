using EStore.BusinessObject.Entities;
using EStore.DataAccess.DTOs;
using EStore.Repositories;
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
        public IActionResult GetAllCategory()
        {
            List<CategoryDTO> categoryResponds = repository.categoryResponds();
            return Ok(categoryResponds);

        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryDTO category)
        {
            repository.CreateCategory(category);
            return Ok(new BaseDTO<CategoryDTO>()
            {
                Success = true,
                Message = "Create new product success",
                Data = category,
            });
        }

        [HttpDelete("id")]
        public IActionResult DeleteCategory(int id)
        {
            var c = repository.GetCategoryByID(id);
            if (c == null)
            {
                return NotFound();
            }
            repository.DeleteCategory(c);
            return Ok(new BaseDTO<Category>()
            {
                Success = true,
                Message = $"Delete product id {id} success",
                Data = c,
            });
        }
        [HttpPut("id")]
        public IActionResult UpdateCategory(int id, CategoryDTO categoryRespond)
        {
            var pTmp = repository.GetCategoryByID(id);
            if (pTmp == null)
            {
                return NotFound();
            }
            repository.UpdateCategory(id, categoryRespond);
            return Ok(new BaseDTO<CategoryDTO>()
            {
                Success = true,
                Message = $"Update category id {id} success!",
                Data = categoryRespond,
            });
        }
    }
}
