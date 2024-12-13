using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.Entitiy.Concrete
{
    public class UserPost
    {
        [Key]
        public int PostId { get; set; }
        public int? UserId { get; set; }
        public string? MediaType { get; set; }
        public string? MediaUrl { get; set; }
        public string? PostContent { get; set; }
        public DateTime? TimeStamp { get; set; }
        public AppUser? User { get; set; }
        public ICollection<UserPostComment>? PostComments { get; set; } 
        public ICollection<UserPostLike> PostLikes { get; set; }

    }
}
