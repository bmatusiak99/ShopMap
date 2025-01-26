using Microsoft.AspNetCore.Mvc;
using Shopify.Api.Entities;
using Shopify.Api.Repositories.Contracts;
using Shopify.Models.Dtos;

namespace Shopify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                // Map OrderDto to Order entity
                var order = new Order
                {
                    UserId = orderDto.UserId,
                    ShopId = orderDto.ShopId,
                    OrderDate = DateTime.Now,
                    TotalPrice = orderDto.TotalPrice,
                    OrderPositions = orderDto.OrderPositions.Select(op => new OrderPosition
                    {
                        ProductId = op.ProductId,
                        ProductName = op.ProductName,
                        ProductPrice = op.ProductPrice,
                        Quantity = op.Quantity,
                        TotalPrice = op.TotalPrice
                    }).ToList()
                };

                // Add order using repository
                int orderId = await _orderRepository.CreateOrderAsync(order);

                return Ok(orderId); // Return created order ID
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

}
