using Shopify.Models.Dtos;
using Shopify.Models.ViewModels;

namespace Shopify.Web.Services.Contracts
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(IEnumerable<CartItemDto> shoppingCartItems, Guid userId, int shopId);
        Task<IEnumerable<OrderViewDto>> GetOrders();
        Task MarkOrderAsRealised(int orderId);
        Task<OrderReportViewModel> GetOrderByIdAsync(int orderId);

    }
}
