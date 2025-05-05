using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shopify.Models.ViewModels;
using Shopify.Web.Services;

namespace Shopify.Web.Pages
{
    public partial class Login : ComponentBase
    {
        private LoginViewModel loginModel = new();

        [Inject] private HttpClient Http { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }
        [Inject] private ILocalStorageService LocalStorage { get; set; }
        [Inject] private AuthenticationStateService AuthStateService { get; set; }

        private async Task HandleLogin()
        {
            var response = await Http.PostAsJsonAsync("api/account/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
                var token = tokenResponse?.Token;

                if (!string.IsNullOrEmpty(token))
                {
                    await LocalStorage.SetItemAsync("access_token", token);
                    Snackbar.Add("Login successful!", Severity.Success);
                    AuthStateService.NotifyAuthenticationChanged();
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    Snackbar.Add("Login failed: Token missing from response.", Severity.Error);
                }
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Snackbar.Add($"Login failed: {errorMessage}", Severity.Error);
            }
        }

        private class TokenResponse
        {
            public string Token { get; set; }
        }

    }
}
