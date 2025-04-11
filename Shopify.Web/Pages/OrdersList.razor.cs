using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Shopify.Models.Dtos;
using Shopify.Web.Reports;
using Shopify.Web.ReportViewModels;
using Shopify.Web.Services;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Pages
{
    public partial class OrdersList : ComponentBase
    {
        protected IEnumerable<OrderViewDto> orders { get; set; }
        [Inject] public IOrderService OrderService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
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


    }
}
