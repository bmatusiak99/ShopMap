using Microsoft.EntityFrameworkCore;
using Shopify.Api.Data;
using Shopify.Api.Entities;
using Shopify.Api.Repositories.Contracts;
using Shopify.Models.Dtos;

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

        public async Task<IEnumerable<ProductReviewDto>> GetReviews(int id)
        {
            return await (from review in this.shopifyDbContext.ProductReviews
                          join user in this.shopifyDbContext.Users on review.UserId equals user.Id
                          where review.ProductId == id
                          select new ProductReviewDto
                          {
                              Id = review.Id,
                              UserName = user.FirstName + " " + user.LastName,
                              ReviewText = review.ReviewText,
                              CreatedAt = review.CreatedAt,
                              Rating = review.Rating
                          }).ToListAsync();
        }

        public async Task<int> CreateReviewAsync(ProductReview review)
        {
            shopifyDbContext.ProductReviews.Add(review);
            await shopifyDbContext.SaveChangesAsync();
            return review.Id;
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            var review = await shopifyDbContext.ProductReviews.FindAsync(reviewId);
            if (review == null)
            {
                return false;
            }

            shopifyDbContext.ProductReviews.Remove(review);
            await shopifyDbContext.SaveChangesAsync();
            return true;
        }

    }
}
