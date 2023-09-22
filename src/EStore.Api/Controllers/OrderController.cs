using EStore.BusinessObject.Entities;
using EStore.DataAccess.DTOs;
using EStore.Repositories;
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
        public IActionResult GetAll()
        {
            List<Order> orders = repository.GetOrders();
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult AddOrder(OrderDTO orderDto)
        {
            repository.SaveOrder(orderDto);
            return Ok(new BaseDTO<OrderDTO>()
            {
                Success = true,
                Message = "Create new product success",
                Data = orderDto,
            });
        }

        [HttpPut("id")]
        public IActionResult UpdateOrder(int id, OrderDTO orderDto)
        {
            var ordTmp = repository.GetOrderByID(id);
            if (ordTmp == null)
            {
                return NotFound();
            }
            repository.UpdateOrder(id, orderDto);
            return Ok(new BaseDTO<OrderDTO>()
            {
                Success = true,
                Message = $"Update product id {id} success!",
                Data = orderDto,
            });
        }

    }
}
