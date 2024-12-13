using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Business.Services;
using NewExcite.Dto.Dtos.AppUserDtos;
using NewExcite.Entitiy.Concrete;
using System;

namespace NewExcite.Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly EmailService _emailService;

        public RegisterController(UserManager<AppUser> userManager, EmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(appUserRegisterDto.Email);

                Random random = new Random();
                int code = random.Next(100000, 1000000);

                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.UserName,
                    Email = appUserRegisterDto.Email,
                    ConfirmCode = code.ToString(),
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    _emailService.SendEmailAsync(appUserRegisterDto.Email, "Doğrulama Kodu", $"6 haneli doğrulama kodunuz: {code}");
                    TempData["Email"] = appUserRegisterDto.Email;
                    return RedirectToAction("Index", "EmailConfirm");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


            }
            return View(appUserRegisterDto);
        }
    }
}
