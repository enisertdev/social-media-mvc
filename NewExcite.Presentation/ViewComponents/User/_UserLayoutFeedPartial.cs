using Microsoft.AspNetCore.Mvc;
using NewExcite.Business.Services.Abstract;
using NewExcite.Presentation.Models;

namespace NewExcite.Presentation.ViewComponents.User
{
    public class _UserLayoutFeedPartial : ViewComponent
    {
        private readonly IUserPostService _userPostService;
        public _UserLayoutFeedPartial(IUserPostService userPostService)
        {
            _userPostService = userPostService;
        }

        public IViewComponentResult Invoke()
        {
            var posts = _userPostService.GetAllPosts().OrderByDescending(u => u.TimeStamp);


            return View(posts);
        }
    }
}
