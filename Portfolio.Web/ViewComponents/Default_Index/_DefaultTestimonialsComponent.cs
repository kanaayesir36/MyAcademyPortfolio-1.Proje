using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultTestimonialsComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
