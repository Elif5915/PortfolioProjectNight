using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        DbMyPortfolioNightEntities entities = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            var values = entities.About.FirstOrDefault();
            return View(values);
        }

        [HttpPost]
        public ActionResult Index(About about)
        {
            var value = entities.About.Find(about.AboutId);
            value.Title = about.Title;
            value.Description = about.Description;
            value.ImageUrl = about.ImageUrl;

            entities.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}