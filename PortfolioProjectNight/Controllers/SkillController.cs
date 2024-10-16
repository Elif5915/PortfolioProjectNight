using System.Linq;
using PortfolioProjectNight.Models;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class SkillController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult SkillList()
        {
            var values = context.Skill.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult createSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createSkill(Skill skill)
        {
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult deleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
              
        }
        public ActionResult updateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult updateSkill(Skill skill)
        {
            var values = context.Skill.Find(skill.SkillId);
            values.SkillName = skill.SkillName;
            values.Rate = skill.Rate;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}