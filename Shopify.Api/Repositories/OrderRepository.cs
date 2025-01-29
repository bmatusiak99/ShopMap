using Microsoft.EntityFrameworkCore;
using Shopify.Api.Data;
using Shopify.Api.Entities;
using Shopify.Api.Repositories.Contracts;
using Shopify.Models.Dtos;

namespace Shopify.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopifyDbContext shopifyDbContext;

        public OrderRepository(ShopifyDbContext shopifyDbContext)
        {
            this.shopifyDbContext = shopifyDbContext;
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            shopifyDbContext.Orders.Add(order);
            await shopifyDbContext.SaveChangesAsync();
            return order.Id;
        }
        public async Task<IEnumerable<OrderViewDto>> GetOrders()
        {
            return await (from order in this.shopifyDbContext.Orders
                          join user in this.shopifyDbContext.Users on order.UserId equals user.Id
                          join shop in this.shopifyDbContext.Shops on order.ShopId equals shop.Id
                          select new OrderViewDto
                          {
                              Id = order.Id,
                              UserName = user.FirstName + " " + user.LastName,
                              OrderDate = order.OrderDate,
                              ShopName = shop.Name,
                              TotalPrice = order.TotalPrice
                          }).ToListAsync();
        }

    }

}
