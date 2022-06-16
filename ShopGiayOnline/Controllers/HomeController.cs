using ShopGiayOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopGiayOnline.Controllers
{
    public class HomeController : Controller
    {
        SHOPGIAYEntities db = new SHOPGIAYEntities();

        public ActionResult Index()
        {
            var top_giay = db.GIAYs.OrderByDescending(s => s.danhgia).Take(6).ToList();
            ViewBag.TopGiay = top_giay;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}