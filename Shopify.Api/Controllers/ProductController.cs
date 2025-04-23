using Microsoft.AspNetCore.Mvc;
using Shopify.Api.Entities;
using Shopify.Api.Extensions;
using Shopify.Api.Repositories.Contracts;
using Shopify.Models.Dtos;

namespace Shopify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await this.productRepository.GetItems();
                var productCategories = await this.productRepository.GetCategories();

                if (products == null || productCategories == null) return NotFound();
                else
                {
                    var productDtos = products.ConvertToDto(productCategories);
                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                var product = await this.productRepository.GetItem(id);

                if (product == null) return BadRequest();
                else
                {
                    var productCategory = await this.productRepository.GetCategory(product.CategoryId);

                    var productDto = product.ConvertToDto(productCategory);

                    return Ok(productDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{id}/GetReviews")]
        public async Task<ActionResult<IEnumerable<ProductReviewDto>>> GetReviews(int id)
        {
            try
            {
                var reviews = await this.productRepository.GetReviews(id);
                if (reviews == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(reviews);
                }


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPost("CreateReview")]
        public async Task<ActionResult<ProductReviewDto>> PostReview([FromBody] ProductReviewToAddDto productReviewToAdd)
        {
            try
            {
                var review = new ProductReview
                {
                    ProductId = productReviewToAdd.ProductId,
                    UserId = productReviewToAdd.UserId,
                    CreatedAt = productReviewToAdd.CreatedAt,
                    Rating = productReviewToAdd.Rating,
                    ReviewText = productReviewToAdd.ReviewText

                };
                int orderId = await productRepository.CreateReviewAsync(review);

                return Ok(orderId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteReview/{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            try
            {
                var result = await productRepository.DeleteReviewAsync(reviewId);

                if (result)
                {
                    return NoContent();
                }

                return NotFound("Review not found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route(nameof(GetProductCategories))]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategories()
        {
            try
            {
                var productCategories = await productRepository.GetCategories();

                var productCategoryDtos = productCategories.ConvertToDto();

                return Ok(productCategoryDtos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error retrieving data from the database");
            }

        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> PostProduct([FromBody] ProductToAddDto productToAdd)
        {
            try
            {
                var product = new Product
                {
                    ProductName = productToAdd.ProductName,
                    ProductDescription = productToAdd.ProductDescription,
                    ProductImage = productToAdd.ProductImage,
                    ProductPrice = productToAdd.ProductPrice,
                    ProductQuantity = productToAdd.ProductQuantity,
                    CategoryId = productToAdd.CategoryId,
                    ShopId = productToAdd.ShopId,
                    ShelfNumber = productToAdd.ShelfNumber
                };

                int productId = await productRepository.CreateProductAsync(product);
                return Ok(productId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
