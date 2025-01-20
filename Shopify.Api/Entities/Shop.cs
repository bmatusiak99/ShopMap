namespace Shopify.Api.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
