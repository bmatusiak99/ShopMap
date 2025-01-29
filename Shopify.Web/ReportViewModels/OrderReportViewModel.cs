namespace Shopify.Web.ReportViewModels
{
    public class OrderReportViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShopName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
