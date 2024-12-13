using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Business.Services.Abstract;
using NewExcite.Entitiy.Concrete;

namespace NewExcite.Presentation.Controllers
{
    public class LikeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserLikeService _userLikeService;

        public LikeController(UserManager<AppUser> userManager, IUserLikeService userLikeService)
        {
            _userManager = userManager;
            _userLikeService = userLikeService;
        }

        public async Task<IActionResult> Dislike(int postId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
         IEnumerable<UserPostLike> userPostLike = _userLikeService.GetLikes(l => l.PostId == postId);
            foreach (var postLike in userPostLike)
            {
                if (postLike.User.UserName == user.UserName)
                {
                    _userLikeService.Delete(postLike);
                }
            }
            return RedirectToAction("Index", "MainPage");
        }

        public async Task<IActionResult> Like(int postId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserPostLike userPostLike = new UserPostLike()
            {
                PostId = postId,
                UserId = user.Id,
                TimeStamp = DateTime.UtcNow
            };
            _userLikeService.Add(userPostLike);
            return RedirectToAction("Index", "MainPage");

        }
    }
}
