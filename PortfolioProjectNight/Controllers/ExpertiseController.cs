using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ExpertiseController : Controller
    {
        DbMyPortfolioNightEntities entities = new DbMyPortfolioNightEntities();
        public ActionResult ExpertiseList()
        {
            var values = entities.Expertise.ToList();
            return View(values);
        }

        public ActionResult CreateExpertise()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExpertise(Expertise expertise)
        {
            entities.Expertise.Add(expertise);
            entities.SaveChanges();
            return RedirectToAction("ExpertiseList");
        }

        public ActionResult deleteExpertise(int id)
        {
           var data =  entities.Expertise.Find(id);
            entities.Expertise.Remove(data);

            entities.SaveChanges();

            return RedirectToAction("ExpertiseList");
        }

        public ActionResult updateExpertise(int id)
        {
            var app = entities.Expertise.Find(id);
            return View(app);
        }
        [HttpPost]
        public ActionResult updateExpertise(Expertise expertise)
        {
            var data = entities.Expertise.Find(expertise.ExpertiseId);
            data.Title = expertise.Title;
            data.Description = expertise.Description;

            entities.SaveChanges();

            return RedirectToAction("ExpertiseList");

        }
    }
}