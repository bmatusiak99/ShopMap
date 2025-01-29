using Shopify.Api.Entities;
using Shopify.Models.Dtos;

namespace Shopify.Api.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderAsync(Order order);
        Task<IEnumerable<OrderViewDto>> GetOrders();
    }

}
