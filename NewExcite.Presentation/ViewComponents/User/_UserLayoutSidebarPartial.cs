using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewExcite.Entitiy.Concrete;
using NewExcite.Presentation.Models;

namespace NewExcite.Presentation.ViewComponents.User
{
    public class _UserLayoutSidebarPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _UserLayoutSidebarPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserViewModel userViewModel = new UserViewModel()
            {
                   Name = user.FirstName,
                   UserName = user.UserName
            };
            return View(userViewModel);
        }
    }
}
