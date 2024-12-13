using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.Entitiy.Concrete
{
    public class UserPostComment
    {
        [Key]
        public int CommentId { get; set; }
        public int? UserId { get; set; }
        public AppUser? User { get; set; }
        public int? PostId { get; set; }
        public UserPost? UserPost { get; set; }
        public string? Comment { get; set; }
        public DateTime? CommentDate { get; set; }
    }
}
