using System.Net.Http.Json;
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

        // Handle login logic
        private async Task HandleLogin()
        {
            // Send login data to API
            var response = await Http.PostAsJsonAsync("api/account/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                // Successful login
                Snackbar.Add("Login successful!", Severity.Success);
                NavigationManager.NavigateTo("/"); // Redirect to the homepage or dashboard
            }
            else
            {
                // Failed login
                var errorMessage = await response.Content.ReadAsStringAsync();
                Snackbar.Add($"Login failed: {errorMessage}", Severity.Error);
            }
        }
    }
}
