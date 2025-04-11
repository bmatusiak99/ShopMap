using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shopify.Models.ViewModels;

namespace Shopify.Web.Pages
{
    public partial class Login : ComponentBase
    {
        private LoginViewModel loginModel = new();

        [Inject] private HttpClient Http { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }
        [Inject] private ILocalStorageService LocalStorage { get; set; }

        // Handle login logic
        private async Task HandleLogin()
        {
            // Send login data to API
            var response = await Http.PostAsJsonAsync("api/account/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response to get the actual token string
                var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
                var token = tokenResponse?.Token;

                if (!string.IsNullOrEmpty(token))
                {
                    await LocalStorage.SetItemAsync("access_token", token); // Store just the token string
                    Snackbar.Add("Login successful!", Severity.Success);
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    Snackbar.Add("Login failed: Token missing from response.", Severity.Error);
                }
            }
            else
            {
                // Failed login
                var errorMessage = await response.Content.ReadAsStringAsync();
                Snackbar.Add($"Login failed: {errorMessage}", Severity.Error);
            }
        }

        // DTO class to parse the JSON response
        private class TokenResponse
        {
            public string Token { get; set; }
        }

    }
}
