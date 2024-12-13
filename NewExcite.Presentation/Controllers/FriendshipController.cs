using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Business.Services.Abstract;
using NewExcite.Entitiy.Concrete;

namespace NewExcite.Presentation.Controllers
{
    [Authorize]
    public class FriendshipController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFriendshipService _friendshipService;

        public FriendshipController(UserManager<AppUser> userManager, IFriendshipService friendshipService)
        {
            _userManager = userManager;
            _friendshipService = friendshipService;
        }

        public async Task<IActionResult> Follow(string userName)
        {
            var followerUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var followedUser = await _userManager.FindByNameAsync(userName);
            UserFriendship userFriendship = new UserFriendship()
            {
                FollowerId = followerUser.Id,
                FollowedId = followedUser.Id,
                CreatedAt = DateTime.UtcNow,
                Status = UserFriendship.FriendshipStatus.Pending
            };
            _friendshipService.Add(userFriendship);

            return RedirectToAction("Index", "MainPage");
        }

        public async Task<IActionResult> Accept(string userName)
        {
            var getFollowed = await _userManager.FindByNameAsync(userName);
            var getCurrent = await _userManager.FindByNameAsync(User.Identity.Name);
            var getRequest = _friendshipService.GetFriend(f => f.UserFollower.UserName == userName && f.Status == UserFriendship.FriendshipStatus.Pending);
            if (getRequest != null)
            {
                getRequest.Status = UserFriendship.FriendshipStatus.Accepted;
                _friendshipService.Update(getRequest);
                return RedirectToAction("Index", "UserProfile", new { userName });
            }
            return View();
        }
        public async Task<IActionResult> FollowBack(string userName)
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var TargetUser = await _userManager.FindByNameAsync(userName);
            UserFriendship getFollower = _friendshipService.GetFriend(f => f.UserFollower.UserName == userName && f.UserFollowed.UserName == currentUser.UserName && f.Status == UserFriendship.FriendshipStatus.Pending);
            if (getFollower != null)
            {
                getFollower.Status = UserFriendship.FriendshipStatus.Accepted;
                getFollower.UpdatedAt = DateTime.UtcNow;
                UserFriendship addTargetUserAsFriend = new UserFriendship()
                {
                    FollowerId = currentUser.Id,
                    FollowedId = TargetUser.Id,
                    Status = UserFriendship.FriendshipStatus.Accepted,
                    CreatedAt = DateTime.UtcNow,
                };
                _friendshipService.Update(getFollower);
                _friendshipService.Add(addTargetUserAsFriend);
                return RedirectToAction("Index","UserProfile", new {userName});
            }
            return NotFound("something went wrong.");
        }
    }
}
