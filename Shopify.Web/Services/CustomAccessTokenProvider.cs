namespace Shopify.Web.Services
{
    using System.Threading.Tasks;
    using Blazored.LocalStorage;

    public class CustomAccessTokenProvider : IAccessTokenProvider
    {
        private readonly ILocalStorageService _localStorage;

        public CustomAccessTokenProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
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
            // Clear the token from local storage (or wherever it's stored)
            await _localStorage.RemoveItemAsync("access_token");
        }
    }

}
