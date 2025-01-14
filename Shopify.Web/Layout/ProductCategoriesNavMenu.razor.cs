using Microsoft.AspNetCore.Components;
using Shopify.Models.Dtos;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Layout
{
    public partial class ProductCategoriesNavMenu : ComponentBase
    {
        [Inject]public IProductService ProductService { get; set; }
        public IEnumerable<ProductCategoryDto> ProductCategoryDtos { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ProductCategoryDtos = await ProductService.GetProductCategories();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
