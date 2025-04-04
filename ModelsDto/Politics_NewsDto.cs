﻿namespace News_Portal.ModelsDto
{
    public class Politics_NewsDto
    {
        public int PoliticsId { get; set; }
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
