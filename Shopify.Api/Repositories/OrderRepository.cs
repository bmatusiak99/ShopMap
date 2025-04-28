using Microsoft.EntityFrameworkCore;
using Shopify.Api.Data;
using Shopify.Api.Entities;
using Shopify.Api.Repositories.Contracts;
using Shopify.Models.Dtos;
using Shopify.Models.ViewModels;

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
                              IsRealised = order.IsRealised,
                              TotalPrice = order.TotalPrice
                          }).ToListAsync();
        }

        public async Task MarkOrderAsRealisedAsync(int orderId)
        {
            var order = await shopifyDbContext.Orders.FindAsync(orderId);
            if (order == null)
                throw new ArgumentException("Order not found");

            order.IsRealised = true;
            await shopifyDbContext.SaveChangesAsync();
        }

        public async Task<OrderReportViewModel> GetOrderByIdAsync(int orderId)
        {
            var order = await shopifyDbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Shop)
                .Include(o => o.OrderPositions)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            return new OrderReportViewModel
            {
                Id = order.Id,
                UserName = $"{order.User.FirstName} {order.User.LastName}",
                UserAddress = order.User.Address,
                UserPhone = order.User.Phone,
                OrderDate = order.OrderDate,
                ShopName = order.Shop.Name,
                ShopAddress = order.Shop.Address,
                ShopPhone = order.Shop.PhoneNumber,
                TotalPrice = order.TotalPrice,
                Products = order.OrderPositions.Select(op => new OrderProductViewModel
                {
                    ProductName = op.ProductName,
                    ProductQuantity = op.Quantity,
                    ProductPrice = op.ProductPrice,
                    ProductTotal = op.TotalPrice
                }).ToList()
            };
        }
    }

}
