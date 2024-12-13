using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.Entitiy.Concrete
{
    public class UserFriendship
    {
        [Key]
        public int FriendshipId { get; set; }
        public int FollowerId { get; set; }
        public int FollowedId { get; set; }
        public AppUser UserFollower { get; set; }
        public AppUser UserFollowed { get; set; }
        public FriendshipStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public enum FriendshipStatus
        {
            Pending,
            Accepted,
            Declined,
            Blocked
        }
    }
}
