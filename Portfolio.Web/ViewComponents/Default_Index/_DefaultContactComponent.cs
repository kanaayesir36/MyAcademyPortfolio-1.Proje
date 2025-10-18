using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultContactComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var contact = context.ContactInfos.ToList();
            return View(contact);
        }
    }
}
