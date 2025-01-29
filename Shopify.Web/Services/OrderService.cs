using Shopify.Models.Dtos;
using Shopify.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Shopify.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient httpClient;

        public OrderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> CreateOrderAsync(IEnumerable<CartItemDto> shoppingCartItems, Guid userId, int shopId)
        {
            try
            {
                var orderDto = new OrderDto
                {
                    UserId = userId,
                    ShopId = shopId,
                    TotalPrice = shoppingCartItems.Sum(item => item.TotalPrice), // Calculate total price
                    OrderPositions = shoppingCartItems.Select(item => new OrderPositionDto
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        ProductPrice = item.ProductPrice,
                        Quantity = item.ProductQuantity,
                        TotalPrice = item.ProductTotalPrice // Assuming it's calculated for the product
                    }).ToList()
                };

                var response = await httpClient.PostAsJsonAsync("api/Order/create", orderDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default; // Or throw an exception if you prefer
                    }

                    var createdOrder = await response.Content.ReadFromJsonAsync<int>();
                    return createdOrder;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the order", ex);
            }
        }
        public async Task<IEnumerable<OrderViewDto>> GetOrders()
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Order");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<OrderViewDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<OrderViewDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
