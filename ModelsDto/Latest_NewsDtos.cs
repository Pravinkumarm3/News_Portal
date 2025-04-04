using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace News_Portal.ModelsDtos
{
    public class Latest_NewsDtos
    {

        public int LatestId { get; set; }
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
    }
}
