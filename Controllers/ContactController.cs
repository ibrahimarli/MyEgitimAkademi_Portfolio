using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEgitimAkademi_Portfolio.Models;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();


        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Description = db.Adress.Select(x => x.Description).FirstOrDefault();
            ViewBag.PhoneNumber = db.Adress.Select(x =>x.PhoneNumber).FirstOrDefault();
            ViewBag.Mail = db.Adress.Select(x => x.Mail).FirstOrDefault();
            ViewBag.AdressDetail = db.Adress.Select(x => x.AdressDetail).FirstOrDefault();

            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            db.Contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("INDEX","Default");
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}