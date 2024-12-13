using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.Entitiy.Concrete
{
    public class UserPostLike
    {
        [Key]
        public int LikeId { get; set; }
        public int PostId { get; set; }
        public UserPost UserPost { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
