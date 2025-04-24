using System.IdentityModel.Tokens.Jwt;
using Blazored.LocalStorage;

namespace Shopify.Web.Services
{
    public class AuthenticationStateService
    {
        public event Action? OnAuthStateChanged;

        private bool _isAdmin;
        private bool _isAuthenticated;
        private string _userName = string.Empty;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;

        public bool IsAdmin => _isAdmin;
        public bool IsAuthenticated => _isAuthenticated;
        public string UserName => _userName;
        public string FirstName => _firstName;
        public string LastName => _lastName;

        public async Task UpdateAuthStateAsync(ILocalStorageService localStorage)
        {
            var token = await localStorage.GetItemAsync<string>("access_token");
            _isAuthenticated = false;
            _userName = string.Empty;
            _firstName = string.Empty;
            _lastName = string.Empty;
            _isAdmin = false;

            if (!string.IsNullOrEmpty(token))
            {
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(token);

                    _firstName = jwtToken.Claims.FirstOrDefault(c => c.Type == "firstName")?.Value ?? "";
                    _lastName = jwtToken.Claims.FirstOrDefault(c => c.Type == "lastName")?.Value ?? "";
                    _userName = $"{_firstName} {_lastName}".Trim();
                    var isAdminClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "isAdmin")?.Value;
                    _isAdmin = bool.TryParse(isAdminClaim, out var result) && result;
                    _isAuthenticated = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error decoding token: {ex.Message}");
                }
            }

            NotifyAuthenticationChanged();
        }

        public void NotifyAuthenticationChanged()
        {
            OnAuthStateChanged?.Invoke();
        }
    }
}