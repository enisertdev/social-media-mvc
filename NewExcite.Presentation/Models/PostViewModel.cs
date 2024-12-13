using NewExcite.Entitiy.Concrete;

namespace NewExcite.Presentation.Models
{
    public class PostViewModel
    {
        public UserPost Post { get; set; }
        public UserPostComment Comment { get; set; }
        public AppUser User { get; set; }
    }
}
