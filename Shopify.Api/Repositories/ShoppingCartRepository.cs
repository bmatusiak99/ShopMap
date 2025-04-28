using Microsoft.EntityFrameworkCore;
using Shopify.Api.Data;
using Shopify.Api.Entities;
using Shopify.Api.Repositories.Contracts;
using Shopify.Models.Dtos;

namespace Shopify.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShopifyDbContext shopifyDbContext;

        public ShoppingCartRepository(ShopifyDbContext shopOnlineDbContext)
        {
            this.shopifyDbContext = shopOnlineDbContext;
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await this.shopifyDbContext.CartItems.AnyAsync(c => c.CartId == cartId && c.ProductId == productId);
        }

        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                var item = await (from product in this.shopifyDbContext.Products
                                  where product.Id == cartItemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = cartItemToAddDto.CartId,
                                      ProductId = product.Id,
                                      Quantity = cartItemToAddDto.ProductQuantity
                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await this.shopifyDbContext.CartItems.AddAsync(item);
                    await this.shopifyDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var item = await this.shopifyDbContext.CartItems.FindAsync(id);

            if (item != null)
            {
                this.shopifyDbContext.CartItems.Remove(item);
                await this.shopifyDbContext.SaveChangesAsync();
            }
            return item;
        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in this.shopifyDbContext.Carts
                          join cartItem in this.shopifyDbContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cartItem.Id == id
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Quantity = cartItem.Quantity,
                              CartId = cartItem.CartId
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(Guid userId)
        {
            return await (from cart in this.shopifyDbContext.Carts
                          join cartItem in this.shopifyDbContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Quantity = cartItem.Quantity,
                              CartId = cartItem.CartId
                          }).ToListAsync();
        }

        public async Task<CartItem> UpdateQty(int id, CartItemQuantityUpdateDto cartItemQtyUpdateDto)
        {
            var item = await this.shopifyDbContext.CartItems.FindAsync(id);

            if (item != null)
            {
                item.Quantity = cartItemQtyUpdateDto.ProductQuantity;
                await this.shopifyDbContext.SaveChangesAsync();
                return item;
            }

            return null;
        }
    }
}
