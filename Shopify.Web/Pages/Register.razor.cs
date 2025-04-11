using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shopify.Models.ViewModels;

namespace Shopify.Web.Pages
{
    public partial class Register
    {
        private RegistrationViewModel registerModel = new();

        [Inject] private HttpClient Http { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private ISnackbar Snackbar { get; set; }

        // Handle the registration logic
        private async Task HandleRegister()
        {
            // Make sure passwords match before sending the request
            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                Snackbar.Add("Passwords do not match!", Severity.Error);
                return;
            }

            // Send the registration data to the API
            var response = await Http.PostAsJsonAsync("api/account/register", registerModel);

            // Handle API response
            if (response.IsSuccessStatusCode)
            {
                Snackbar.Add("Registration successful!", Severity.Success);
                NavigationManager.NavigateTo("/account/login"); // Redirect to login after successful registration
            }
            else
            {
                // Handle errors (you can display the error message from the API here)
                var errorMessage = await response.Content.ReadAsStringAsync();
                Snackbar.Add($"Registration failed: {errorMessage}", Severity.Error);
            }
        }
    }
}
