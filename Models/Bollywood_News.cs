using System.ComponentModel.DataAnnotations;

namespace News_Portal.Models
{
    public class Bollywood_News
    {
        [Key]
        public int BollywoodId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public string FullNews { get; set; }
        public string Status { get; set; }
        public string NewsType { get; set; }
        public DateOnly CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateOnly ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
