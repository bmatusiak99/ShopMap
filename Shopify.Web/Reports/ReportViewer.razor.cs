using DevExpress.Blazor.Reporting;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Components;
using Shopify.Models.ViewModels;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Reports
{
    public partial class ReportViewer : ComponentBase
    {
        [Parameter] public int orderId { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IOrderService OrderService { get; set; }
        public DxReportViewer reportViewer { get; set; }
        public XtraReport Report { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var orderReportViewModel = await LoadOrderData(orderId);
            Report = new OrderReport(orderReportViewModel);
        }

        private async Task<OrderReportViewModel> LoadOrderData(int orderId)
        {
            var order = await OrderService.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                NavigationManager.NavigateTo("/OrdersList");
                return new OrderReportViewModel();
            }

            return order;
        }


        private void GoBack()
        {
            NavigationManager.NavigateTo("/OrdersList");
        }
    }
}
