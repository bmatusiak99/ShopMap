using Shopify.Models.Dtos;

namespace Shopify.Web.Services.Contracts
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(IEnumerable<CartItemDto> shoppingCartItems, Guid userId, int shopId);
        Task<IEnumerable<OrderViewDto>> GetOrders();

    }
}
