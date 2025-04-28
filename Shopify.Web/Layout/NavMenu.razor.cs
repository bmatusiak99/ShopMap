using System.IdentityModel.Tokens.Jwt;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace Shopify.Web.Layout
{
    public partial class NavMenu
    {
        [Inject] private NavigationManager Navigation { get; set; }
        [Inject] ILocalStorageService LocalStorage { get; set; }
        private bool isAdmin;
        private bool isAuthenticated;

        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private int shoppingCartItemsCount = 0;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected async override void OnInitialized()
        {
            var token = await LocalStorage.GetItemAsync<string>("access_token");
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var isAdminClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "isAdmin")?.Value;
                isAdmin = bool.TryParse(isAdminClaim, out var result) && result;

            }


            shoppingCartService.OnShoppingCartChanged += ShoppingCartChanged;
        }
        private void ShoppingCartChanged(int totalQty)
        {
            shoppingCartItemsCount = totalQty;
            StateHasChanged();
        }
        void IDisposable.Dispose()
        {
            shoppingCartService.OnShoppingCartChanged -= ShoppingCartChanged;
        }
        private void NavigateToOrders()
        {
            Navigation.NavigateTo("/OrdersList");
        }
    }
}
