using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ChartController : Controller
    {
        DbMyPortfolioNightEntities entities = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            var skills = entities.Skill.ToList();

            var skillName = skills.Select(x => x.SkillName).ToList();
            var skillRate = skills.Select(y => y.Rate).ToList();

            ViewBag.skillName = skillName;
            ViewBag.skillRate = skillRate;

            return View();
        }
    }
}