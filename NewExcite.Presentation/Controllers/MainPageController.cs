using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Business.Services.Abstract;
using NewExcite.DataAccess.Abstract;
using NewExcite.DataAccess.Repositories;
using NewExcite.Entitiy.Concrete;
using NewExcite.Presentation.Models;

namespace NewExcite.Presentation.Controllers
{
    [Authorize]
    public class MainPageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserPostService _userPostService;

        public MainPageController(UserManager<AppUser> userManager, IUserPostService userPostService)
        {
            _userManager = userManager;
            _userPostService = userPostService;

        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user.FirstName == null || user.LastName == null || user.City == null || user.PhoneNumber == null || user.State == null || user.UserName == user.Email)
            {
                return RedirectToAction("IntroduceYourself", "UserIntroduce");
            }
            return View();
        }
        public async Task<IActionResult> CreatePost(PostCreateViewModel postCreateViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var post = new UserPost()
            {
                TimeStamp = DateTime.UtcNow,
                PostContent = postCreateViewModel.PostContent,
                MediaType = postCreateViewModel.MediaType,
                UserId = user.Id,
                MediaUrl = postCreateViewModel.MediaUrl
            };
            _userPostService.Add(post);
            return RedirectToAction("Index");
        }

    }
}
