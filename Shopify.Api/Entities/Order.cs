namespace Shopify.Api.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int ShopId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsRealised { get; set; }
        public ICollection<OrderPosition> OrderPositions { get; set; }
    }

}
