using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Entitiy.Concrete;
using NewExcite.Presentation.Models;

namespace NewExcite.Presentation.Controllers
{
    public class EmailConfirmController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmailConfirmController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = TempData["Email"];
            ViewBag.Email = value;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(EmailConfirmViewModel emailConfirmViewModel)
        {
            var user = await _userManager.FindByEmailAsync(emailConfirmViewModel.Email);
            if (user != null)
            {
                if (user.ConfirmCode == emailConfirmViewModel.ConfirmCode)
                {
                    user.EmailConfirmed = true;
                    user.ConfirmCode = null;
                    await _userManager.UpdateAsync(user);
                    return RedirectToAction("SuccessCallback", "EmailConfirm");
                }
            }
            ViewBag.Email = emailConfirmViewModel.Email;
            ModelState.AddModelError("", "Kod yanlış veya kullanıcı bulunamadı.");
            return View();
        }
        public IActionResult SuccessCallBack()
        {
            return View();
        }
    }
}
