using Shopify.Models.ViewModels;

namespace Shopify.Web.Reports
{
    public partial class OrderReport : DevExpress.XtraReports.UI.XtraReport
    {
        public OrderReportViewModel ViewModel { get; set; }
        public OrderReport(OrderReportViewModel viewModel)
        {
            InitializeComponent();
            this.ViewModel = ViewModel;

            this.objectDataSource1.DataSource = viewModel;
        }
    }
}
