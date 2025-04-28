﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shopify.Models.Dtos;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Pages
{
    public partial class ShoppingCart : ComponentBase
    {
        [Inject] public IJSRuntime Js { get; set; }

        [Inject] public IShoppingCartService ShoppingCartService { get; set; }
        [Inject] public IAccountService AccountService { get; set; }

        public List<CartItemDto> ShoppingCartItems { get; set; }
        public string ErrorMessage { get; set; }
        protected string TotalPrice { get; set; }
        protected int TotalQuantity { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var userInfo = await AccountService.GetUserInfoAsync();
                ShoppingCartItems = await ShoppingCartService.GetItems(Guid.Parse(userInfo.Id));
                CartChanged();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task DeleteCartItem_Click(int id)
        {
            var cartItemDto = await ShoppingCartService.DeleteItem(id);
            await RemoveCartItem(id);
            CartChanged();
        }
        private async Task RemoveCartItem(int id)
        {
            var cartItemDto = GetCartItem(id);
            ShoppingCartItems.Remove(cartItemDto);
        }

        protected async Task UpdateQtyCartItem_Click(int id, int qty)
        {
            if (qty > 0)
            {
                var updateItemDto = new CartItemQuantityUpdateDto
                {
                    CartItemId = id,
                    ProductQuantity = qty
                };

                var returnedUpdateItemDto = await this.ShoppingCartService.UpdateQty(updateItemDto);
                await UpdateItemTotalPrice(returnedUpdateItemDto);

                CalculateCartSummaryTotals();
                CartChanged();

                await MakeUpdateQtyButtonVisible(id, false);
            }
            else
            {
                var item = this.ShoppingCartItems.FirstOrDefault(i => i.Id == id);

                if (item != null)
                {
                    item.ProductQuantity = 1;
                    item.TotalPrice = item.ProductPrice;
                }
            }
        }

        protected async Task UpdateQty_Input(int id) => await Js.InvokeVoidAsync("MakeUpdateQtyButtonVisible", id, true);
        private async Task MakeUpdateQtyButtonVisible(int id, bool visible) => await Js.InvokeVoidAsync("MakeUpdateQtyButtonVisible", id, visible);
        private void SetTotalPrice() => TotalPrice = this.ShoppingCartItems.Sum(p => p.TotalPrice).ToString("C");
        private void SetTotalQuantity() => TotalQuantity = this.ShoppingCartItems.Sum(p => p.ProductQuantity);
        private CartItemDto GetCartItem(int id) { return ShoppingCartItems.FirstOrDefault(i => i.Id == id); }

        private async Task UpdateItemTotalPrice(CartItemDto cartItemDto)
        {
            var item = GetCartItem(cartItemDto.Id);

            if (item != null)
            {
                item.TotalPrice = cartItemDto.ProductPrice * cartItemDto.ProductQuantity;
            }

        }
        private void CalculateCartSummaryTotals()
        {
            SetTotalPrice();
            SetTotalQuantity();
        }
        private void CartChanged()
        {
            CalculateCartSummaryTotals();
            ShoppingCartService.RaiseEventOnShoppingCartChanged(TotalQuantity);
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
