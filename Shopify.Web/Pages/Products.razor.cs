using Microsoft.AspNetCore.Components;
using Shopify.Models.Dtos;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Pages
{
    public partial class Products
    {
        [Inject] public IProductService ProductService { get; set; }
        [Inject] public IShoppingCartService ShoppingCartService { get; set; }
        public IEnumerable<ProductDto> ProductsList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ProductsList = await ProductService.GetItems();
            var shoppingCartItems = await ShoppingCartService.GetItems(Guid.Parse("79E9147F-44E3-4026-8BB6-061EF1CEFE4C"));
            var totalQty = shoppingCartItems.Sum(i => i.ProductQuantity);

            ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQty);
        }
        protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductsByCategory()
        {
            return from product in ProductsList
                   group product by product.CategoryId into prodByCatGroup
                   orderby prodByCatGroup.Key
                   select prodByCatGroup;
        }
        protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductDto)
        {
            return groupedProductDto.FirstOrDefault(pg => pg.CategoryId == groupedProductDto.Key).CategoryName;
        }
    }
}
