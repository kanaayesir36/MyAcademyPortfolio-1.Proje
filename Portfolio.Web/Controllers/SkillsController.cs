using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class SkillsController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var skills=context.Skills.ToList();
            return View(skills);
        }

        public IActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            context.Skills.Add(skill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSkill(int id)
        {
            var updates = context.Skills.Find(id);

            return View(updates);
        }

        [HttpPost]

        public IActionResult UpdateSkill(Skill skill)
        {
            context.Skills.Update(skill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
           var deletes=context.Skills.Find(id);
            context.Skills.Remove(deletes);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
