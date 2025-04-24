using System.IdentityModel.Tokens.Jwt;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shopify.Models.Dtos;
using Shopify.Web.Pages.Dialogs;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Pages
{
    public partial class Products
    {
        [Inject] public IProductService ProductService { get; set; }
        [Inject] public IShoppingCartService ShoppingCartService { get; set; }
        [Inject] public IDialogService DialogService { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        private bool isAdmin;
        public IEnumerable<ProductDto> ProductsList { get; set; }

        protected override async Task OnInitializedAsync()
        {

            var token = await LocalStorage.GetItemAsync<string>("access_token");
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var isAdminClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "isAdmin")?.Value;
                isAdmin = bool.TryParse(isAdminClaim, out var result) && result;
            }

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

        private async Task OpenAddProductDialog()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true };

            var dialog = DialogService.Show<AddProductDialog>("Add Product", parameters, options);

            var result = await dialog.Result;

            if (!result.Canceled)
            {
                // Product was added, refresh the list
                ProductsList = await ProductService.GetItems();
                StateHasChanged();
            }
        }

    }
}
