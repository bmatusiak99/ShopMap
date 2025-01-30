using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Shopify.Web.Pages.ShopMaps
{
    public partial class BeautyShopMap
    {
        [CascadingParameter] private IMudDialogInstance MudDialog { get; set; }
        [Parameter] public int? SelectedShelfId { get; set; }

        private void Submit() => MudDialog.Close(DialogResult.Ok(true));

        private void Cancel() => MudDialog.Cancel();

        private void OnShelfClick(int shelfId)
        {
            SelectedShelfId = shelfId;
        }

        private List<Shelf> Shelves = new()
        {
            // Left-side aisle
            new Shelf { Id = 1, X = 50, Y = 100, Width = 30, Height = 80 },
            new Shelf { Id = 2, X = 50, Y = 200, Width = 30, Height = 80 },
            new Shelf { Id = 3, X = 50, Y = 300, Width = 30, Height = 80 },
            new Shelf { Id = 4, X = 50, Y = 400, Width = 30, Height = 80 },

            // Middle aisles
            new Shelf { Id = 5, X = 200, Y = 100, Width = 30, Height = 80 },
            new Shelf { Id = 6, X = 200, Y = 200, Width = 30, Height = 80 },
            new Shelf { Id = 7, X = 200, Y = 300, Width = 30, Height = 80 },
            new Shelf { Id = 8, X = 200, Y = 400, Width = 30, Height = 80 },

            new Shelf { Id = 9, X = 350, Y = 100, Width = 30, Height = 80 },
            new Shelf { Id = 10, X = 350, Y = 200, Width = 30, Height = 80 },
            new Shelf { Id = 11, X = 350, Y = 300, Width = 30, Height = 80 },
            new Shelf { Id = 12, X = 350, Y = 400, Width = 30, Height = 80 },

            new Shelf { Id = 13, X = 500, Y = 100, Width = 30, Height = 80 },
            new Shelf { Id = 14, X = 500, Y = 200, Width = 30, Height = 80 },
            new Shelf { Id = 15, X = 500, Y = 300, Width = 30, Height = 80 },
            new Shelf { Id = 16, X = 500, Y = 400, Width = 30, Height = 80 },

            // Right-side aisle
            new Shelf { Id = 17, X = 650, Y = 100, Width = 30, Height = 80 },
            new Shelf { Id = 18, X = 650, Y = 200, Width = 30, Height = 80 },
            new Shelf { Id = 19, X = 650, Y = 300, Width = 30, Height = 80 },
            new Shelf { Id = 20, X = 650, Y = 400, Width = 30, Height = 80 },

        };

    }
}
