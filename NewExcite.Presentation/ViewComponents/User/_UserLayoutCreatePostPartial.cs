using Microsoft.AspNetCore.Mvc;

namespace NewExcite.Presentation.ViewComponents.User
{
    public class _UserLayoutCreatePostPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
