using Microsoft.AspNetCore.Components;

namespace Shopify.Web.Layout
{
    public partial class NavMenu
    {
        [Inject] private NavigationManager Navigation { get; set; }

        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private int shoppingCartItemsCount = 0;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected override void OnInitialized()
        {
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
