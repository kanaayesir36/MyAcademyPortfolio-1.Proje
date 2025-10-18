using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Portfolio.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AboutController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var aboutList = _context.Abouts.ToList();

            return View(aboutList);
        }

        public IActionResult UpdateAbout(int id)
        {
            var item = _context.Abouts.Find(id);
            return View(item);
        }

        [HttpPost]
        public  IActionResult UpdateAbout(About about)
        {
            _context.Update(about);
            _context.SaveChanges();

           return  RedirectToAction("Index");
        }

        public IActionResult CreateAbout()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _context.Add(about);
            _context.SaveChanges(); 
            return  RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {
            var item = _context.Abouts.Find(id);
            _context.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
           
        }
    }
}