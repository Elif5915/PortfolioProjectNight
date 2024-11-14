using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class SocialMediaController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult SocialMediaList()
        {
            var values = context.SocialMedia.ToList();
            return View(values);
        }

        public ActionResult CreateSocialMedia()
		{
            return View();
		}
        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();

            return RedirectToAction("SocialMediaList");
        }

        public ActionResult UpdateSocialMedia(int id)
		{
            var data = context.SocialMedia.Find(id);
            return View(data);
		}

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var values = context.SocialMedia.Find(socialMedia.SocialMediaId);
            values.Title = socialMedia.Title;
            values.Url = socialMedia.Url;
            values.Status = socialMedia.Status;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult deleteSocialMedia(int id)
		{
            var data = context.SocialMedia.Find(id);
            context.SocialMedia.Remove(data);
            context.SaveChanges();

            return RedirectToAction("SocialMediaList");

        }
    }
}