using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Shopify.Web.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("access_token");

            var identity = string.IsNullOrEmpty(token)
                ? new ClaimsIdentity()
                : new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "User") }, "jwt");

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        public void NotifyUserLogout()
        {
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }
    }


    // Access Token Logic
    public interface IAccessTokenProvider
    {
        Task<AccessTokenRequestResult> RequestAccessToken();
        Task LogoutAsync();
    }

    public class AccessTokenRequestResult
    {
        public AccessTokenRequestResultStatus Status { get; set; }
        public string AccessToken { get; set; }
    }

    public enum AccessTokenRequestResultStatus
    {
        Success,
        Failure
    }

}
