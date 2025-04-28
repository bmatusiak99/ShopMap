using System.IdentityModel.Tokens.Jwt;
using Blazored.LocalStorage;
using Shopify.Models.Dtos;
using Shopify.Web.Services.Contracts;

namespace Shopify.Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILocalStorageService _localStorage;

        public AccountService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<UserInfoDto> GetUserInfoAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("access_token");
            if (string.IsNullOrEmpty(token))
                return null;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var userInfo = new UserInfoDto
            {
                Id = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value,
                UserName = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId)?.Value,
                FirstName = jwtToken.Claims.FirstOrDefault(c => c.Type == "firstName")?.Value,
                LastName = jwtToken.Claims.FirstOrDefault(c => c.Type == "lastName")?.Value,
                IsAdmin = bool.TryParse(jwtToken.Claims.FirstOrDefault(c => c.Type == "isAdmin")?.Value, out var isAdmin) && isAdmin
            };

            return userInfo;
        }
    }
}
