using Microsoft.AspNetCore.Identity;

namespace News_Portal.DbConnection
{
    public class ApplicationUsers : IdentityUser
    {
       // public string Role { get; set; }
        // "Admin" or "User "
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
