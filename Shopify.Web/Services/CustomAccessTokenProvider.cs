namespace Shopify.Web.Services
{
    using System.Threading.Tasks;
    using Blazored.LocalStorage;

    public class CustomAccessTokenProvider : IAccessTokenProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateService _authStateService;

        public CustomAccessTokenProvider(ILocalStorageService localStorage, AuthenticationStateService authStateService)
        {
            _localStorage = localStorage;
            _authStateService = authStateService;
        }

        public async Task<AccessTokenRequestResult> RequestAccessToken()
        {
            var token = await _localStorage.GetItemAsync<string>("access_token");
            if (string.IsNullOrEmpty(token))
            {
                return new AccessTokenRequestResult
                {
                    Status = AccessTokenRequestResultStatus.Failure
                };
            }

            return new AccessTokenRequestResult
            {
                Status = AccessTokenRequestResultStatus.Success,
                AccessToken = token
            };
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("access_token");
            _authStateService.NotifyAuthenticationChanged();
        }
    }

}
