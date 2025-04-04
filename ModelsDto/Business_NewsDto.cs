namespace News_Portal.ModelsDto
{
    public class Business_NewsDto
    {
        public int BusinessId { get; set; }
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
