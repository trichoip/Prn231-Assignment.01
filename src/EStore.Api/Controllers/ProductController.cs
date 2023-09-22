using EStore.BusinessObject.Entities;
using EStore.DataAccess.DTOs;
using EStore.Repositories;
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
        public IActionResult GetAll(string? search)
        {
            List<ProductDTO> products = repository.GetProducts(search);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductByID(int id)
        {
            Product productRespond = repository.GetProductByID(id);
            return Ok(productRespond);
        }

        [HttpPost]
        public IActionResult PostProduct(ProductDTO product)
        {
            repository.SaveProduct(product);
            return Ok(new BaseDTO<ProductDTO>()
            {
                Success = true,
                Message = "Create new product success",
                Data = product,
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductByID(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(p);
            return Ok(new BaseDTO<Product>()
            {
                Success = true,
                Message = $"Delete product id {id} success",
                Data = p,
            });
        }
        [HttpPut("{id}")]

        public IActionResult UpdateProduct(int id, ProductDTO productRespond)
        {
            var pTmp = repository.GetProductByID(id);
            if (pTmp == null)
            {
                return NotFound();
            }
            repository.UpdateProduct(id, productRespond);
            return Ok(new BaseDTO<ProductDTO>()
            {
                Success = true,
                Message = $"Update product id {id} success!",
                Data = productRespond,
            });
        }

    }
}
