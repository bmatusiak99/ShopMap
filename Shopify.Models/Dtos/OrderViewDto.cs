namespace Shopify.Models.Dtos
{
    public class OrderViewDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShopName { get; set; }
        public bool IsRealised { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
