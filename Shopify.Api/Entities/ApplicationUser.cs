using Microsoft.AspNetCore.Identity;

namespace Shopify.Api.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public bool IsAdmin { get; set; }
    }
}
