using Shopify.Models.Dtos;

namespace Shopify.Web.Services.Contracts
{
    public interface IAccountService
    {
        Task<UserInfoDto> GetUserInfoAsync();
    }
}
