using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class EducationController : Controller
    {
        private readonly PortfolioContext _context;

        public EducationController(PortfolioContext context)
        {
            _context = context;
        }

        // Listeleme
        public IActionResult Index()
        {
            var items = _context.Educations.ToList();
            return View(items);
        }

        // Güncelleme GET
        public IActionResult UpdateEducation(int id)
        {
            var item = _context.Educations.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // Güncelleme POST
        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            if (education == null)
            {
                return BadRequest();
            }

            _context.Update(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Oluşturma GET
        public IActionResult CreateEducation()
        {
            return View();
        }

        // Oluşturma POST
        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            if (education == null)
            {
                return BadRequest();
            }

            _context.Add(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Silme
        public IActionResult DeleteEducation(int id)
        {
            var item = _context.Educations.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
