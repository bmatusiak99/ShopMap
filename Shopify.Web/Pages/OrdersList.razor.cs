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
        protected override async Task OnInitializedAsync()
        {
            try
            {
                //ShoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();
                orders = await OrderService.GetOrders();

            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        public void Print(int OrderId)
        {
            var orderReportViewModel = new OrderReportViewModel();
            XtraReport report = new OrderReport(orderReportViewModel);


        }


    }
}
