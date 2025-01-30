using DevExpress.Blazor.Reporting;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Components;
using Shopify.Web.ReportViewModels;

namespace Shopify.Web.Reports
{
    public partial class ReportViewer : ComponentBase
    {
        [Parameter] public int orderId { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        public DxReportViewer reportViewer { get; set; }
        public XtraReport Report { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var orderReportViewModel = await LoadOrderData(orderId);
            Report = new OrderReport(orderReportViewModel);
        }

        private async Task<OrderReportViewModel> LoadOrderData(int orderId)
        {
            await Task.Delay(500);

            return new OrderReportViewModel
            {
                Id = orderId,
                UserName = "John Doe",
                OrderDate = DateTime.UtcNow,
                ShopName = "Best Electronics",
                TotalPrice = 149.99m
            };
        }


        private void GoBack()
        {
            NavigationManager.NavigateTo("/OrdersList");
        }
    }
}
