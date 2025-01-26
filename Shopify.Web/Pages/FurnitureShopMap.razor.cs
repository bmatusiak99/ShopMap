using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;

namespace Shopify.Web.Pages
{
    public partial class FurnitureShopMap
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
            //Left wall shelfs
            new Shelf { Id = 1, X = 60, Y = 185, Width = 30, Height = 68 },
            new Shelf { Id = 2, X = 60, Y = 258, Width = 30, Height = 68 },
            new Shelf { Id = 3, X = 60, Y = 331, Width = 30, Height = 68 },
            new Shelf { Id = 4, X = 60, Y = 404, Width = 30, Height = 68 },
            new Shelf { Id = 5, X = 60, Y = 477, Width = 30, Height = 68 },

            //Middle shelfs
            new Shelf { Id = 6, X = 205, Y = 185, Width = 30, Height = 68 },
            new Shelf { Id = 7, X = 205, Y = 258, Width = 30, Height = 68 },
            new Shelf { Id = 8, X = 205, Y = 331, Width = 30, Height = 68 },
            new Shelf { Id = 9, X = 205, Y = 404, Width = 30, Height = 68 },
            new Shelf { Id = 10, X = 205, Y = 477, Width = 30, Height = 68 },

            new Shelf { Id = 11, X = 240, Y = 185, Width = 30, Height = 68 },
            new Shelf { Id = 12, X = 240, Y = 258, Width = 30, Height = 68 },
            new Shelf { Id = 13, X = 240, Y = 331, Width = 30, Height = 68 },
            new Shelf { Id = 14, X = 240, Y = 404, Width = 30, Height = 68 },
            new Shelf { Id = 15, X = 240, Y = 477, Width = 30, Height = 68 },

            new Shelf { Id = 16, X = 385, Y = 185, Width = 30, Height = 68 },
            new Shelf { Id = 17, X = 385, Y = 258, Width = 30, Height = 68 },
            new Shelf { Id = 18, X = 385, Y = 331, Width = 30, Height = 68 },
            new Shelf { Id = 19, X = 385, Y = 404, Width = 30, Height = 68 },
            new Shelf { Id = 20, X = 385, Y = 477, Width = 30, Height = 68 },


            new Shelf { Id = 21, X = 420, Y = 185, Width = 30, Height = 68 },
            new Shelf { Id = 22, X = 420, Y = 258, Width = 30, Height = 68 },
            new Shelf { Id = 23, X = 420, Y = 331, Width = 30, Height = 68 },
            new Shelf { Id = 24, X = 420, Y = 404, Width = 30, Height = 68 },
            new Shelf { Id = 25, X = 420, Y = 477, Width = 30, Height = 68 },

            //Top wall shelfs
            new Shelf { Id = 26, X = 130, Y = 60, Width = 70, Height = 30 },
            new Shelf { Id = 27, X = 205, Y = 60, Width = 70, Height = 30 },
            new Shelf { Id = 28, X = 280, Y = 60, Width = 70, Height = 30 },
            new Shelf { Id = 29, X = 355, Y = 60, Width = 70, Height = 30 },
            new Shelf { Id = 30, X = 430, Y = 60, Width = 70, Height = 30 },
            new Shelf { Id = 31, X = 505, Y = 60, Width = 70, Height = 30 },
            new Shelf { Id = 32, X = 580, Y = 60, Width = 70, Height = 30 },
            new Shelf { Id = 33, X = 655, Y = 60, Width = 70, Height = 30 },

            //Right wall shelfs
            new Shelf { Id = 34, X = 710, Y = 185, Width = 30, Height = 68 },
            new Shelf { Id = 35, X = 710, Y = 258, Width = 30, Height = 68 },
            new Shelf { Id = 36, X = 710, Y = 331, Width = 30, Height = 68 },
            new Shelf { Id = 37, X = 710, Y = 404, Width = 30, Height = 68 },
            new Shelf { Id = 38, X = 710, Y = 477, Width = 30, Height = 68 },
        };

    }
    public class Shelf
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
