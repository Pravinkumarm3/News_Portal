using System.ComponentModel.DataAnnotations;

namespace News_Portal.Models
{
    public class UserModel
    {
        [Key]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
