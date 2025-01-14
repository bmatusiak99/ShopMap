using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Models.Dtos
{
    public class CartItemQuantityUpdateDto
    {
        public int CartItemId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
