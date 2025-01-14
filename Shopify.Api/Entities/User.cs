namespace Shopify.Api.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ImageURL { get; set; }
        public int RoleId { get; set; }

    }
}
