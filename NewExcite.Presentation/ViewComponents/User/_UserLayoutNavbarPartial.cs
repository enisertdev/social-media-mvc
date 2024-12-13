using Microsoft.AspNetCore.Mvc;

namespace NewExcite.Presentation.ViewComponents.User
{
    public class _UserLayoutNavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
