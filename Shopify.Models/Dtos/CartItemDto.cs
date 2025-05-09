﻿namespace Shopify.Models.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public byte[]? ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int CartId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
