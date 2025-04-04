using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace News_Portal.Models
{
    public class MultiplePhotoUpload
    {
        [Key]
        public int id { get; set; }
        public string FileName { get; set; }
        public string? FileName1 { get; set; }
        public string? FileName2 { get; set; }
      //  public byte[] Image { get; set; }
        [ForeignKey("TrendingId")]
        public int TrendingId { get; set; }
        public Trending_News? trending_News { get; set; }
       
    }
}
