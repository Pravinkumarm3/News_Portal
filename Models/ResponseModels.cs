using System.ComponentModel.DataAnnotations;

namespace News_Portal.Models
{
    public class ResponseModels
    {
        [Key]
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
