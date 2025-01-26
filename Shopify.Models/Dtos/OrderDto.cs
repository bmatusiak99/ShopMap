using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Models.Dtos
{
    public class OrderDto
    {
        public Guid UserId { get; set; }
        public int ShopId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderPositionDto> OrderPositions { get; set; }
    }
}
