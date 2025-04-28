namespace Shopify.Models.ViewModels
{
    public class OrderReportViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserPhone { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string ShopPhone { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderProductViewModel> Products { get; set; }
    }

    public class OrderProductViewModel
    {
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductTotal { get; set; }
    }
}
