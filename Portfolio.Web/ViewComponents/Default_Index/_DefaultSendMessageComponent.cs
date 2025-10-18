using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultSendMessageComponent:ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
