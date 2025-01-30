using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Shopify.Web.Pages.ShopMaps
{
    public partial class ElectronicsShopMap
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
            new Shelf { Id = 1, X = 100, Y = 120, Width = 30, Height = 80 },
            new Shelf { Id = 2, X = 100, Y = 220, Width = 30, Height = 80 },
            new Shelf { Id = 3, X = 100, Y = 320, Width = 30, Height = 80 },
            new Shelf { Id = 4, X = 100, Y = 420, Width = 30, Height = 80 },

            // Middle aisles
            new Shelf { Id = 5, X = 250, Y = 120, Width = 30, Height = 80 },
            new Shelf { Id = 6, X = 250, Y = 220, Width = 30, Height = 80 },
            new Shelf { Id = 7, X = 250, Y = 320, Width = 30, Height = 80 },
            new Shelf { Id = 8, X = 250, Y = 420, Width = 30, Height = 80 },

            new Shelf { Id = 9, X = 400, Y = 120, Width = 30, Height = 80 },
            new Shelf { Id = 10, X = 400, Y = 220, Width = 30, Height = 80 },
            new Shelf { Id = 11, X = 400, Y = 320, Width = 30, Height = 80 },
            new Shelf { Id = 12, X = 400, Y = 420, Width = 30, Height = 80 },

            // Right-side aisle
            new Shelf { Id = 13, X = 550, Y = 120, Width = 30, Height = 80 },
            new Shelf { Id = 14, X = 550, Y = 220, Width = 30, Height = 80 },
            new Shelf { Id = 15, X = 550, Y = 320, Width = 30, Height = 80 },
            new Shelf { Id = 16, X = 550, Y = 420, Width = 30, Height = 80 },

        };

        public class Shelf
        {
            public int Id { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }
    }
}
