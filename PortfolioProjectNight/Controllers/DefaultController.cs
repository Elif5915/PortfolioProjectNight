using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using SelectListItem = System.Web.Mvc.SelectListItem;

namespace PortfolioProjectNight.Controllers
{
    public class DefaultController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            List<SelectListItem> values = (from x in context.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contact.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.IsRead = false;
            context.Contact.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialHeader()
        {
            ViewBag.title = context.Profile.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.address = context.Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.Phone).FirstOrDefault();
            ViewBag.github = context.Profile.Select(x => x.Github).FirstOrDefault();
            ViewBag.imageUrl = context.Profile.Select(x => x.ImageUrl).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            var values = context.About.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialExperience()
        {
            var values = context.Experience.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = context.Skill.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialEducation()
        {
            var edu = context.Education.ToList();
            return PartialView(edu);
        }
        
        public PartialViewResult PartialInternShip()
        {
            var staj = context.InternShip.ToList();
            return PartialView(staj);
        }

        public PartialViewResult PartialService()
        {
            var service = context.Service.ToList();
            return PartialView(service);
        }

        public PartialViewResult PartialPortfolio()
        {
            var values = context.Expertise.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialReference()
        {
            var reference = context.Reference.ToList();
            return PartialView(reference);
        }
    }
}