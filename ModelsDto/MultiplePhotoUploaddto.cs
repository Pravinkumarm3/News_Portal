using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using News_Portal.Models;
using News_Portal.ModelsDto;

namespace News_Portal.ModelsDtos
{
    public class MultiplePhotoUploaddto
    {
        
        public int id { get; set; }
        public string FileName { get; set; }
        public string? FileName1 { get; set; }
        public string? FileName2 { get; set; }
       // public byte[] Image { get; set; }
        [ForeignKey("TrendingId")]
        public int TrendingId { get; set; }
        public Trending_NewsDto? trending_News { get; set; }
        
    }
}
