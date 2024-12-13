using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Dto.Dtos.AppUserDtos;
using NewExcite.Entitiy.Concrete;

namespace NewExcite.Presentation.Controllers
{
    [Authorize]
    public class UserIntroduceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserIntroduceController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> IntroduceYourself()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            AppUserIntroduceDto appUserIntroduceDto = new AppUserIntroduceDto()
            {
                UserName = user.UserName,
                City = user.City,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                State = user.State
            };
            return View(appUserIntroduceDto);

        }
        [HttpPost]
        public async Task<IActionResult> IntroduceYourself(AppUserIntroduceDto appUserIntroduceDto)
        {
            var user = await _userManager.FindByEmailAsync(appUserIntroduceDto.Email);
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            user.UserName = appUserIntroduceDto.UserName;
            user.PhoneNumber = appUserIntroduceDto.PhoneNumber;
            user.FirstName = appUserIntroduceDto.FirstName;
            user.LastName = appUserIntroduceDto.LastName;
            user.City = appUserIntroduceDto.City;
            user.State = appUserIntroduceDto.State;
            await _userManager.UpdateAsync(user);
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","MainPage");
        }
    }
}
