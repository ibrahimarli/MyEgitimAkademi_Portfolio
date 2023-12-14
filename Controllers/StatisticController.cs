using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEgitimAkademi_Portfolio.Models;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class StatisticController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            ViewBag.TotalProjectCount = db.Project.Count();
            ViewBag.TotalTestimonialCount = db.Testimonial.Count();
            ViewBag.SumWorkDay = db.Project.Sum(x => x.ComplateDay);
            ViewBag.AvgWorkDay = db.Project.Average(x => x.ComplateDay);
            ViewBag.AvgPrice = db.Project.Average(x => (double)x.Price);
            var value = db.Project.Max(x => x.Price);
            ViewBag.MaxPricerProject = db.Project.Where(x => x.Price == value).Select(y=>y.Title).FirstOrDefault();


            var value2 = db.Category.Where(x => x.CategoryName == "AspNet Core Web Geliştirme").Select(y => y.CategoryId).FirstOrDefault();
            ViewBag.CategoryCountByName = db.Project.Where(x => x.ProjectCategory == value2).Count();
            return View();
        }
    }
}