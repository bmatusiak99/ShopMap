using Shopify.Api.Entities;
using Shopify.Models.Dtos;

namespace Shopify.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductCategoryDto> ConvertToDto(this IEnumerable<ProductCategory> productCategories)
        {
            return (from productCategory in productCategories
                    select new ProductCategoryDto
                    {
                        Id = productCategory.Id,
                        Name = productCategory.CategoryName,
                        IconCSS = productCategory.IconCSS
                    }).ToList();
        }

        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products, 
            IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products
                    join productCategory in productCategories
                    on product.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        ProductImageURL = product.ProductImageURL,
                        ProductPrice = product.ProductPrice,
                        ProductQuantity = product.ProductQuantity,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory.CategoryName,
                        ShopId = product.ShopId,
                        ShelfNumber = product.ShelfNumber
                    }).ToList();
        }

        public static ProductDto ConvertToDto(this Product product, ProductCategory productCategory)
        {
            return new ProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductImageURL = product.ProductImageURL,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = productCategory.CategoryName,
                ShopId = product.ShopId,
                ShelfNumber = product.ShelfNumber
            };

        }

        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,
                                                            IEnumerable<Product> products)
        {
            return (from cartItem in cartItems
                    join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductId = cartItem.ProductId,
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        ProductImageURL = product.ProductImageURL,
                        ProductPrice = product.ProductPrice,
                        CartId = cartItem.CartId,
                        ProductQuantity = cartItem.Quantity,
                        TotalPrice = product.ProductPrice * cartItem.Quantity
                    }).ToList();
        }
        public static CartItemDto ConvertToDto(this CartItem cartItem,
                                                    Product product)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductImageURL = product.ProductImageURL,
                ProductPrice = product.ProductPrice,
                CartId = cartItem.CartId,
                ProductQuantity = cartItem.Quantity,
                TotalPrice = product.ProductPrice * cartItem.Quantity
            };
        }


    }
}
