using System.ComponentModel.DataAnnotations;

namespace News_Portal.Models
{
    public class FileModals
    {

        [Key]
        public int id { get; set; }
        public string FileName { get; set; }
    }
}
