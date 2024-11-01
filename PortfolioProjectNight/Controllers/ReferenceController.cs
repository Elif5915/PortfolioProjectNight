using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ReferenceController : Controller
    {
        DbMyPortfolioNightEntities entities = new DbMyPortfolioNightEntities();
        public ActionResult ReferenceList()
        {
            var values = entities.Reference.ToList();
            return View(values);
        }

        public ActionResult deleteReference(int id)
        {
            var values = entities.Reference.Find(id);
            entities.Reference.Remove(values);
            entities.SaveChanges();

            return RedirectToAction("ReferenceList");
        }
        public ActionResult addReference()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addReference(Reference reference)
        {
            entities.Reference.Add(reference);
            entities.SaveChanges();

            return RedirectToAction("ReferenceList");
        }

        public ActionResult updateReference(int id)
        {
            var values = entities.Reference.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult updateReference(Reference reference)
        {
            var data = entities.Reference.Find(reference.ReferenceId);
            data.Title = reference.Title;
            data.NameSurname = reference.NameSurname;
            data.SubTitle = reference.SubTitle;

            entities.SaveChanges();
            return RedirectToAction("ReferenceList");
        }
    }
}