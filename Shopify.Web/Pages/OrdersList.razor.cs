using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shopify.Models.Dtos;
using Shopify.Web.Pages.Dialogs;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Pages
{
    public partial class OrdersList : ComponentBase
    {
        protected IEnumerable<OrderViewDto> orders { get; set; }
        [Inject] public IOrderService OrderService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IDialogService dialogService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                orders = await OrderService.GetOrders();

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ShowReport(int orderId)
        {
            NavigationManager.NavigateTo($"/viewer/{orderId}");
        }

        private async Task ConfirmMarkAsRealised(int orderId)
        {
            var parameters = new DialogParameters
            {
                { "ContentText", "Are you sure you want to mark this order as realised?" },
                { "ButtonText", "Yes" },
                { "Color", Color.Success }
            };

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

            var dialog = dialogService.Show<DeleteDialog>("Mark as Realised", parameters, options);
            var result = await dialog.Result;

            if (!result.Canceled)
            {
                await OrderService.MarkOrderAsRealised(orderId);
                orders = await OrderService.GetOrders();
            }
        }

    }
}
