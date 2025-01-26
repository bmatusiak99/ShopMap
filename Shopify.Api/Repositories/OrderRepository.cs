using Microsoft.EntityFrameworkCore;
using Shopify.Api.Data;
using Shopify.Api.Entities;
using Shopify.Api.Repositories.Contracts;

namespace Shopify.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopifyDbContext _shopifyDbContext;

        public OrderRepository(ShopifyDbContext shopifyDbContext)
        {
            _shopifyDbContext = shopifyDbContext;
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            _shopifyDbContext.Orders.Add(order);
            await _shopifyDbContext.SaveChangesAsync();
            return order.Id;
        }
    }

}
