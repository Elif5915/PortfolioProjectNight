using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class DashboardController : Controller
    {
        DbMyPortfolioNightEntities entities = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            ViewBag.eduCount = entities.Education.Count();
            ViewBag.skill = entities.Skill.Count();
            ViewBag.service = entities.Service.Count();
            return View();
        }
    }
}