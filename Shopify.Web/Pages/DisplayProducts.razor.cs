using Microsoft.AspNetCore.Components;
using Shopify.Models.Dtos;

namespace Shopify.Web.Pages
{
    public partial class DisplayProducts
    {
        [Parameter] public IEnumerable<ProductDto> ProductsList { get; set; }

    }
}
