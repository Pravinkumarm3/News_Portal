using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using News_Portal.ModelsDtos;

namespace News_Portal.Models
{
    public class Trending_News
    {
        [Key]
       // public IFormFile File { get; set; }
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDiscription { get; set; }
        public string FullNews { get; set; }
        public string Thumbnail { get; set; }
        public string NewsStatus { get; set; }
        public DateTime NewsDateTime { get; set; }
        public string CreatedBy { get; set; }
        public DateOnly CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateOnly ModifiedOn { get; set; }
        public List<MultiplePhotoUpload> Images { get; set; } = new List<MultiplePhotoUpload>();



    }
}
