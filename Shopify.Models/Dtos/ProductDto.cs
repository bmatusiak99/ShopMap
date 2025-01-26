﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageURL { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ShopId { get; set; }
        public int? ShelfNumber { get; set; }
    }
}
