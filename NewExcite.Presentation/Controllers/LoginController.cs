using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Dto.Dtos.AppUserDtos;
using NewExcite.Entitiy.Concrete;
using System.Security.Claims;

namespace NewExcite.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "MainPage");
            }
            AppUserLoginDto loginDto = new AppUserLoginDto()
            {
                Schemes = await _signInManager.GetExternalAuthenticationSchemesAsync()
            };
            return View(loginDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserLoginDto appUserLoginDto)
        {
            appUserLoginDto.Schemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
            var user = await _userManager.FindByNameAsync(appUserLoginDto.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                return View(appUserLoginDto);
            }

            var result = await _signInManager.PasswordSignInAsync(appUserLoginDto.UserName, appUserLoginDto.Password, false, true);
            if (result.Succeeded)
            {

                return RedirectToAction("Index", "MainPage");

            }
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Hesabınız kısa süreliğine bloke oldu.Lütfen daha sonra tekrar deneyin.");
                return View(appUserLoginDto);
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
            return View(appUserLoginDto);
        }

        public IActionResult ExternalLogin(string provider, string returnUrl = "")
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Login", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallBack(string returnurl = "", string remoteError = "")
        {
            AppUserLoginDto loginDto = new AppUserLoginDto()
            {
                Schemes = await _signInManager.GetExternalAuthenticationSchemesAsync()
            };

            if (remoteError != "")
            {
                ModelState.AddModelError("", $"Hata {remoteError}");
                return View("Index", loginDto);
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError("", $"Hata {remoteError}");
                return View("Index", loginDto);
            }
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "MainPage");
            }
            else
            {
                var userEmail = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var user = await _userManager.FindByEmailAsync(userEmail);
                    if (user == null)
                    {
                        user = new AppUser()
                        {
                            UserName = userEmail,
                            Email = userEmail,
                            EmailConfirmed = true
                        };
                        await _userManager.CreateAsync(user);
                    }
                    if (user.LockoutEnd > DateTimeOffset.UtcNow)
                    {
                        ModelState.AddModelError("", "Hesabınız kısa süreliğine bloke oldu.Lütfen daha sonra tekrar deneyin.");
                        return View("Index", loginDto);
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "MainPage");
                }
                ModelState.AddModelError("", $"Something went wrong");
                return View("Index", loginDto);
            }

        }
    }
}