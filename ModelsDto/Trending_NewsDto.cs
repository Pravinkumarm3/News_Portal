using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using News_Portal.Models;
using News_Portal.ModelsDtos;

namespace News_Portal.ModelsDto
{
    public class Trending_NewsDto
    {

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
        public List<MultiplePhotoUploaddto> Images { get; set; } = new List<MultiplePhotoUploaddto>();



    }
}
