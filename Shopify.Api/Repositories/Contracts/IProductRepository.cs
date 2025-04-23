using Shopify.Api.Entities;
using Shopify.Models.Dtos;

namespace Shopify.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductReviewDto>> GetReviews(int id);
        Task<int> CreateReviewAsync(ProductReview review);
        Task<bool> DeleteReviewAsync(int reviewId);
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Product> GetItem(int id);
        Task<ProductCategory> GetCategory(int id);
        Task<int> CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task SoftDeleteProductAsync(int productId);
    }
}
