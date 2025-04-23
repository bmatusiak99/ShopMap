using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shopify.Models.Dtos;
using Shopify.Web.Pages.ShopMaps;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Pages
{
    public partial class ProductDetails : ComponentBase
    {
        [Parameter] public int Id { get; set; }
        [Inject] public IProductService ProductService { get; set; }
        [Inject] public IShoppingCartService ShoppingCartService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IDialogService _dialogService { get; set; }
        protected IEnumerable<ProductReviewDto> productReviews { get; set; }
        private ProductReviewToAddDto newReview = new ProductReviewToAddDto();
        protected int AverageRating { get; set; }
        public ProductDto Product { get; set; }
        public string ErrorMessage { get; set; }
        private List<CartItemDto> ShoppingCartItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetItem(Id);
                productReviews = await ProductService.GetReviews(Id);

                CalculateAverageRating();
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
        private async void SubmitReview()
        {
            if (!string.IsNullOrWhiteSpace(newReview.ReviewText) && newReview.Rating > 0)
            {
                var review = new ProductReviewToAddDto
                {
                    ProductId = Product.Id,
                    UserId = Guid.Parse("79e9147f-44e3-4026-8bb6-061ef1cefe4c"),
                    ReviewText = newReview.ReviewText,
                    Rating = newReview.Rating,
                    CreatedAt = DateTime.Now
                };

                await ProductService.AddReview(review);

                productReviews = await ProductService.GetReviews(Product.Id);
                newReview = new ProductReviewToAddDto();
                StateHasChanged();
            }
        }

        private async void DeleteReview(int reviewId)
        {
            await ProductService.RemoveReview(reviewId);
            productReviews = await ProductService.GetReviews(Product.Id);
            StateHasChanged();
        }

        private void CalculateAverageRating() => AverageRating = productReviews.Any() ? (int)Math.Round(productReviews.Average(x => x.Rating)) : 0;

        protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var cartItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);
                NavigationManager.NavigateTo("/ShoppingCart");
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
        private Task NavigateToMap()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Large };

            var parameters = new DialogParameters
            {
                { "SelectedShelfId", Product.ShelfNumber.Value }
            };

            return Product.ShopId switch
            {
                1 => _dialogService.ShowAsync<ElectronicsShopMap>("Electronics Shop", parameters, options),
                2 => _dialogService.ShowAsync<BeautyShopMap>("Beauty Shop", parameters, options),
                4 => _dialogService.ShowAsync<ShoesShopMap>("Shoes Shop", parameters, options),
                _ => Task.CompletedTask
            };
        }

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
