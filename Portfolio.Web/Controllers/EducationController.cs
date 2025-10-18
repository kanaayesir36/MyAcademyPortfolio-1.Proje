
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class EducationController : Controller
    {
        public IActionResult Index()
        {
            // Experience entity kullanılarak dummy veri gönderiliyor
            var experiences = new List<Experience>
            {
                new Experience { ExperienceId = 1, Title = "Yazılım Geliştirici", Company = "ABC Teknoloji", City = "İstanbul", StartYear = 2022, EndYear = "2025" },
                new Experience { ExperienceId = 2, Title = "Stajyer Mühendis", Company = "XYZ Yazılım", City = "Ankara", StartYear = 2021, EndYear = "2022" },
                new Experience { ExperienceId = 3, Title = "Freelance Web Developer", Company = "Serbest", City = "Online", StartYear = 2023, EndYear = null }
            };

            return View(experiences); // Model null olmasın
        }
    }
}