using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.Models.Dtos
{
    public class ProductReviewDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating { get; set; }
    }
}
