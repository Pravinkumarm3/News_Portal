using System.ComponentModel.DataAnnotations;

namespace News_Portal.Models
{
    public class LoginModels
    {
        [Key]
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
