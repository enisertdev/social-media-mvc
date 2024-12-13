namespace NewExcite.Presentation.Models
{
    public class PostCreateViewModel
    {
        public int UserId { get; set; }
        public string MediaType { get; set; }
        public string MediaUrl { get; set; }
        public string PostContent { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
