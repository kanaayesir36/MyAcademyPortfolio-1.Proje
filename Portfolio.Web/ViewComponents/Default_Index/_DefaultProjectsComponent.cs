using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultProjectsComponent(PortfolioContext context):ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            var categoriesWithProjects=context.Categories.Include(c=> c.Projects).ToList();
            return View(categoriesWithProjects);
        }
    }
}
