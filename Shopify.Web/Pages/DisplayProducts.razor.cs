using Microsoft.AspNetCore.Components;
using Shopify.Models.Dtos;

namespace Shopify.Web.Pages
{
    public partial class DisplayProducts
    {
        [Parameter] public IEnumerable<ProductDto> ProductsList { get; set; }

        public string GetProductImageBase64(byte[] productImage)
        {
            if (productImage != null && productImage.Length > 0)
            {
                return $"data:image/png;base64,{Convert.ToBase64String(productImage)}";
            }
            return string.Empty;
        }

    }
}
