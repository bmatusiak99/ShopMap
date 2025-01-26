using Shopify.Api.Entities;

namespace Shopify.Api.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderAsync(Order order);
    }

}
