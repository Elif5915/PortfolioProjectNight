using PortfolioProjectNight.Models;
using System.Linq;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class DefaultController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            return View();
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
        
    }
}