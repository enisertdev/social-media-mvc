using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Entitiy.Concrete;

namespace NewExcite.Presentation.Controllers
{
    public class LogoutController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View();
        }
    }
}
