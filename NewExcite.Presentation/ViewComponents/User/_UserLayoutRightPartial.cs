using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Business.Services.Abstract;
using NewExcite.Entitiy.Concrete;
using NewExcite.Presentation.Models;

namespace NewExcite.Presentation.ViewComponents.User
{
    public class _UserLayoutRightPartial : ViewComponent
    {
        private readonly IFriendshipService _friendshipService;
        private readonly UserManager<AppUser> _userManager;

        public _UserLayoutRightPartial(IFriendshipService friendshipService, UserManager<AppUser> userManager)
        {
            _friendshipService = friendshipService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = await _userManager.FindByNameAsync(User.Identity.Name);
            var followRequests = _friendshipService.GetFriends(f => f.FollowedId == userId.Id && f.Status == UserFriendship.FriendshipStatus.Pending).ToList();
            IEnumerable<FollowRequestsViewModel> followRequestsViewModel = followRequests
                .Select(f => new FollowRequestsViewModel()
                {
                    FollowerName = f.UserFollower.FirstName,
                    FollowerLastName = f.UserFollower.LastName,
                    FollowerUserName = f.UserFollower.UserName
                })
                .ToList();
            return View(followRequestsViewModel);
        }
    }
}
