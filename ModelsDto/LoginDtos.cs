using System.ComponentModel.DataAnnotations;

namespace News_Portal.ModelsDtos
{
    public class LoginDtos
    {
       
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
