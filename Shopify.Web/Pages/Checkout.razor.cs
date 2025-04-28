using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shopify.Models.Dtos;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Pages
{
    public partial class Checkout : ComponentBase
    {
        [Inject] public IJSRuntime Js { get; set; }
        protected IEnumerable<CartItemDto> ShoppingCartItems { get; set; }
        protected int TotalQty { get; set; }
        protected string PaymentDescription { get; set; }
        protected decimal PaymentAmount { get; set; }
        [Inject] public IShoppingCartService ShoppingCartService { get; set; }
        [Inject] public IOrderService OrderService { get; set; }
        [Inject] public IAccountService AccountService { get; set; }
        private DotNetObjectReference<Checkout>? _dotNetRef;
        private Guid userId;

        protected string DisplayButtons { get; set; } = "block";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _dotNetRef = DotNetObjectReference.Create(this);
                await Js.InvokeVoidAsync("initPayPalButton", _dotNetRef);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var userInfo = await AccountService.GetUserInfoAsync();
            userId = Guid.Parse(userInfo.Id);
            ShoppingCartItems = await ShoppingCartService.GetItems(userId);

            if (ShoppingCartItems != null && ShoppingCartItems.Count() > 0)
            {
                Guid orderGuid = Guid.NewGuid();

                PaymentAmount = ShoppingCartItems.Sum(p => p.TotalPrice);
                TotalQty = ShoppingCartItems.Sum(p => p.ProductQuantity);
                PaymentDescription = $"O_{Guid.Parse(userInfo.Id)}_{orderGuid}";
            }
            else
            {
                DisplayButtons = "none";
            }

        }

        [JSInvokable("CreateOrderAfterPayment")]
        public async Task CreateOrderAfterPayment()
        {
            Console.WriteLine("JSInvokable method called successfully!");
            try
            {
                var createdOrder = await OrderService.CreateOrderAsync(ShoppingCartItems, userId, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateOrderAfterPayment: {ex.Message}");
            }
        }

        public void Dispose() => _dotNetRef?.Dispose();

    }
}