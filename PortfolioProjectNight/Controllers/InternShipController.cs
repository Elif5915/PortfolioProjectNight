using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProjectNight.Models;

namespace PortfolioProjectNight.Controllers
{
    public class InternShipController : Controller
    {
        // GET: InterShip

        DbMyPortfolioNightEntities entities = new DbMyPortfolioNightEntities();
       
        public ActionResult InternShipList()
        {
            var values = entities.InternShip.ToList();
            return View(values);
        }

        public ActionResult createInternShip()
        {
            return View();

        }

        [HttpPost]
        public ActionResult createInternShip(InternShip ınternShip)
        {
            entities.InternShip.Add(ınternShip);
            entities.SaveChanges();
            return RedirectToAction("InternShipList");

        }

        public ActionResult updateInternShip(int id)
        {
            var values = entities.InternShip.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult updateInternShip(InternShip ınternShip)
        {
            var values = entities.InternShip.Find(ınternShip.InternShipId);
            values.Title = ınternShip.Title;
            values.SubTitle = ınternShip.SubTitle;
            values.Description = ınternShip.Description;
            entities.SaveChanges();
            return RedirectToAction("InternShipList");
        }

        public ActionResult deleteInternShip(int id)
        {
            var values = entities.InternShip.Find(id);
            entities.InternShip.Remove(values);
            entities.SaveChanges();
            return RedirectToAction("InternShipList");
        }
    }
}