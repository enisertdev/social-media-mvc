using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Business.Services;
using NewExcite.Business.Services.Abstract;
using NewExcite.Entitiy.Concrete;
using NewExcite.Presentation.Models;

namespace NewExcite.Presentation.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserPostService _userPostService;
        private readonly IFriendshipService _friendshipService;

        public UserProfileController(UserManager<AppUser> userManager, IUserPostService userPostService, IFriendshipService friendshipService)
        {
            _userManager = userManager;
            _userPostService = userPostService;
            _friendshipService = friendshipService;
        }
        [HttpPost("UserProfile/{userName}")]
        [HttpGet("UserProfile/{userName}")]
        public async Task<IActionResult> Index(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var posts = _userPostService.GetPosts(p => p.User == user).Count();
            var userFollowers = _friendshipService.GetFriends(f => f.UserFollowed.UserName == userName && f.Status == UserFriendship.FriendshipStatus.Accepted).Count();
            var userFollowings = _friendshipService.GetFriends(f => f.UserFollower.UserName == userName && f.Status == UserFriendship.FriendshipStatus.Accepted).Count();
            bool doUsersFollowingEachOther = _friendshipService.GetFriends(f => f.UserFollower.UserName == currentUser.UserName && f.UserFollowed.UserName == userName && f.Status == UserFriendship.FriendshipStatus.Accepted).Any();
            bool doTargetUserFollowingCurrentAndNotBeenAccepted = _friendshipService.GetFriends(f => f.UserFollower.UserName == userName && f.Status == UserFriendship.FriendshipStatus.Pending).Any();
            bool isCurrentUserFollowingButNotBeenAccepted = _friendshipService.GetFriends(f => f.UserFollower.UserName == currentUser.UserName && f.UserFollowed.UserName == userName && f.Status == UserFriendship.FriendshipStatus.Pending).Any();


            ProfileViewModel profileViewModel = new ProfileViewModel()
            {
                UserName = userName,
                FollowCount = userFollowings,
                FollowerCount = userFollowers,
                PostCount = posts,
                UsersFollowingEachOther = doUsersFollowingEachOther,
                TargetUserFollowingCurrentAndNotBeenAccepted = doTargetUserFollowingCurrentAndNotBeenAccepted,
                CurrentUserFollowingButNotBeenAccepted = isCurrentUserFollowingButNotBeenAccepted

            };
            return View(profileViewModel);
        }
    }
}
