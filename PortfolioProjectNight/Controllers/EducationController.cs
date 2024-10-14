using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class EducationController : Controller
    {
        DbMyPortfolioNightEntities entities = new DbMyPortfolioNightEntities();
        public ActionResult EducationList()
        {
            var edu = entities.Education.ToList();
            return View(edu);
        }

        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            entities.Education.Add(education);
            entities.SaveChanges();

            return RedirectToAction("EducationList");
        }

        public ActionResult deleteEducation(int id)
        {
            var eduId = entities.Education.Find(id);
            entities.Education.Remove(eduId);
            entities.SaveChanges();
            return RedirectToAction("EducationList");
        }

        public ActionResult updateEducation(int id)
        {
            var edu = entities.Education.Find(id);
            return View(edu);
        }

        [HttpPost]
        public ActionResult updateEducation(Education education)
        {
            var updateEdu = entities.Education.Find(education.EducationId);
            updateEdu.Title = education.Title;
            updateEdu.SubTitle = education.SubTitle;
            updateEdu.Description = education.Description;

            entities.SaveChanges();

            return RedirectToAction("EducationList");
        }
    }
}