using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class ServiceController : Controller
    {
        DbMyPortfolioNightEntities entities = new DbMyPortfolioNightEntities();
        public ActionResult ServiceList()
        {
            var values = entities.Service.ToList();
            return View(values);
        }
        public ActionResult CreateService()
		{
            return View();
		}

        [HttpPost]
        public ActionResult CreateService(Service service)
		{
            entities.Service.Add(service);
            entities.SaveChanges();

          return RedirectToAction("ServiceList");
		}

        public ActionResult UpdateService(int id)
		{
            var data = entities.Service.Find(id);
            return View(data);
		}

        [HttpPost]
        public ActionResult UpdateService(Service service)
		{
            var data = entities.Service.Find(service.ServiceId);
            data.Title = service.Title;
            data.Description = service.Description;

            entities.SaveChanges();
            return RedirectToAction("ServiceList");
		}

        public ActionResult deleteService(int id)
		{
           var data = entities.Service.Find(id);
            entities.Service.Remove(data);
            entities.SaveChanges();

            return RedirectToAction("ServiceList");

		}
    }
}