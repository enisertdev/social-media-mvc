using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Business.Services.Abstract;
using NewExcite.Entitiy.Concrete;

namespace NewExcite.Presentation.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly IUserCommentService _userCommentService;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(IUserCommentService userCommentService, UserManager<AppUser> userManager)
        {
            _userCommentService = userCommentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> CreateComment(int postId, string comment, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
           UserPostComment userPostComment = new UserPostComment()
           {
               PostId = postId,
               Comment = comment,
               UserId = user.Id,
               CommentDate = DateTime.UtcNow
           };
            _userCommentService.AddComment(userPostComment);
            return RedirectToAction("Index","MainPage");
        }
    }
}
