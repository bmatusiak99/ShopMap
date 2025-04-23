using Shopify.Models.Dtos;

namespace Shopify.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
        Task<ProductDto> GetItem(int id);
        Task<IEnumerable<ProductReviewDto>> GetReviews(int id);
        Task<int> AddReview(ProductReviewToAddDto newReview);
        Task RemoveReview(int reviewId);
        Task<IEnumerable<ProductCategoryDto>> GetProductCategories();
        Task<IEnumerable<ProductDto>> GetItemsByCategory(int categoryId);

        Task<int> AddProduct(ProductToAddDto newProduct);
    }
}
