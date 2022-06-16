using ShopGiayOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopGiayOnline.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        private SHOPGIAYEntities db = new SHOPGIAYEntities();
        public ActionResult Index()
        {
            if(Session["username"] != null)
            {
                if (Session["type"].Equals("admin"))
                {
                    return RedirectToAction("Index","Dashboard");
                } 
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string tendangnhap, string matkhau)
        {
            if (ModelState.IsValid)
            {
                var data = db.TAIKHOANCHUs.Where(s => s.tendangnhap.Equals(tendangnhap) && s.matkhau.Equals(matkhau)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["username"] = data.FirstOrDefault().tendangnhap;
                    Session["password"] = data.FirstOrDefault().matkhau;
                    Session["type"] = "admin";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }
}
