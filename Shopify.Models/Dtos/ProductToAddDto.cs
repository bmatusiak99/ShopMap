namespace Shopify.Models.Dtos
{
    public class ProductToAddDto
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
    }

}
