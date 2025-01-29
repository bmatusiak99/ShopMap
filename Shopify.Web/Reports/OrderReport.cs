using DevExpress.XtraReports.UI;
using Shopify.Web.ReportViewModels;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

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
