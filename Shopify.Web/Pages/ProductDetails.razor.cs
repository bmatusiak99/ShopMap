using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shopify.Models.Dtos;

using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Pages
{
    public partial class ProductDetails : ComponentBase
    {
        [Parameter] public int Id { get; set; }
        [Inject] public IProductService ProductService { get; set; }
        [Inject] public IShoppingCartService ShoppingCartService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IDialogService _dialogService { get; set; }
        public ProductDto Product { get; set; }
        public string ErrorMessage { get; set; }
        private List<CartItemDto> ShoppingCartItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetItem(Id);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
        protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var cartItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);
                NavigationManager.NavigateTo("/ShoppingCart");
                //if (cartItemDto != null)
                //{
                //    ShoppingCartItems.Add(cartItemDto);
                //    await ManageCartItemsLocalStorageService.SaveCollection(ShoppingCartItems);
                //}

                //NavigationManager.NavigateTo("/ShoppingCart");
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
        private Task NavigateToMap()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Large };

            var parameters = new DialogParameters
            {
                { "SelectedShelfId", Product.ShelfNumber.Value }
            };

            return _dialogService.ShowAsync<FurnitureShopMap>("Dialog Title", parameters, options);
        }
    }
}
