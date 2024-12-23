﻿using PortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class MessageController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult Inbox()
        {
            var values = context.Contact.ToList();
            return View(values);
        }

        public ActionResult changeMessageStatusToTrue(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult changeMessageStatusToFalse(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult deleteMessage(int id)
        {
            var message = context.Contact.Find(id);
            context.Contact.Remove(message);
            context.SaveChanges();

            return RedirectToAction("Inbox");
        }

        public ActionResult openDetailMessage(int id)
        {
            var value = context.Contact.Find(id);
           if(value.IsRead == false)
            {
                value.IsRead = true;
            }
            context.SaveChanges();
            return View(value);
        }

    }
}