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


        private async Task HandleRegister()
        {
            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                Snackbar.Add("Passwords do not match!", Severity.Error);
                return;
            }

            var response = await Http.PostAsJsonAsync("api/account/register", registerModel);

            if (response.IsSuccessStatusCode)
            {
                Snackbar.Add("Registration successful!", Severity.Success);
                NavigationManager.NavigateTo("/account/login");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Snackbar.Add($"Registration failed: {errorMessage}", Severity.Error);
            }
        }
    }
}
