using Shopify.Api.Entities;
using Shopify.Models.Dtos;
using Shopify.Models.ViewModels;

namespace Shopify.Api.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderAsync(Order order);
        Task<IEnumerable<OrderViewDto>> GetOrders();
        Task MarkOrderAsRealisedAsync(int orderId);
        Task<OrderReportViewModel> GetOrderByIdAsync(int orderId);
    }

}
