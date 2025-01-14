﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shopify.Models.Dtos;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Pages
{
    public partial class Checkout : ComponentBase
    {
        [Inject]public IJSRuntime Js { get; set; }
        protected IEnumerable<CartItemDto> ShoppingCartItems { get; set; }
        protected int TotalQty { get; set; }
        protected string PaymentDescription { get; set; }
        protected decimal PaymentAmount { get; set; }
        [Inject]public IShoppingCartService ShoppingCartService { get; set; }

        //[Inject]public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }


        protected string DisplayButtons { get; set; } = "block";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //ShoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();
                ShoppingCartItems = await ShoppingCartService.GetItems(Guid.Parse("79E9147F-44E3-4026-8BB6-061EF1CEFE4C"));

                if (ShoppingCartItems != null && ShoppingCartItems.Count() > 0)
                {
                    Guid orderGuid = Guid.NewGuid();

                    PaymentAmount = ShoppingCartItems.Sum(p => p.TotalPrice);
                    TotalQty = ShoppingCartItems.Sum(p => p.ProductQuantity);
                    PaymentDescription = $"O_{Guid.Parse("79E9147F-44E3-4026-8BB6-061EF1CEFE4C")}_{orderGuid}";

                }
                else
                {
                    DisplayButtons = "none";
                }

            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await Js.InvokeVoidAsync("initPayPalButton");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
