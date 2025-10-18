using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly PortfolioContext _context;

        public TestimonialController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Testimonials.ToList();
            return View(items);
        }
    }
}