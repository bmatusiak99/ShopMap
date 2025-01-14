using Microsoft.EntityFrameworkCore;
using Shopify.Api.Data;
using Shopify.Api.Entities;
using Shopify.Api.Repositories.Contracts;

namespace Shopify.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopifyDbContext shopifyDbContext;

        public ProductRepository(ShopifyDbContext shopifyDbContext)
        {
            this.shopifyDbContext = shopifyDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.shopifyDbContext.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await shopifyDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await shopifyDbContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.shopifyDbContext.Products.ToListAsync();

            return products;
        }
    }
}
