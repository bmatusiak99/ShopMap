using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Shopify.Web;
using Shopify.Web.Services;
using Shopify.Web.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient setup
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7125/") });

// Service registrations
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Add MudBlazor, DevExpress, and other services
builder.Services.AddMudServices();
builder.Services.AddDevExpressBlazor();
builder.Services.AddDevExpressServerSideBlazorReportViewer();

// Authentication & Authorization
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IAccessTokenProvider, CustomAccessTokenProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddBlazoredLocalStorage();


// Build and run the app
await builder.Build().RunAsync();
