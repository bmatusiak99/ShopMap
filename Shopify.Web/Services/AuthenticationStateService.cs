namespace Shopify.Web.Services
{
    public class AuthenticationStateService
    {
        public event Action? OnAuthStateChanged;

        public void NotifyAuthenticationChanged()
        {
            OnAuthStateChanged?.Invoke();
        }
    }
}
