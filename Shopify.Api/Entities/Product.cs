namespace Shopify.Api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public byte[]? ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int CategoryId { get; set; }
        public int? ShopId { get; set; }
        public int? ShelfNumber { get; set; }
        public bool IsDeleted { get; set; }
        public Shop? Shop { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }
    }
}
