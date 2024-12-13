using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.Entitiy.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ConfirmCode { get; set; }
        public ICollection<UserPost> UserPosts { get; set; }
        public ICollection<UserPostComment>? UserPostComments { get; set; }
        public ICollection<UserPostLike> UserPostLikes { get; set; }
        public ICollection<UserFriendship> FollowedBy { get; set; }
        public ICollection<UserFriendship> Following { get; set; }


    }
}
