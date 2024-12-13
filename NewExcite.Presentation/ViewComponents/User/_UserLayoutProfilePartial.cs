using Microsoft.AspNetCore.Mvc;

namespace NewExcite.Presentation.ViewComponents.User
{
    public class _UserLayoutProfilePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
