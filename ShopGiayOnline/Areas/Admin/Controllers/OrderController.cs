using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopGiayOnline.Models;

namespace ShopGiayOnline.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private SHOPGIAYEntities db = new SHOPGIAYEntities();

        // GET: Admin/Order
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                var hOADONs = db.HOADONs.Include(h => h.TAIKHOAN);
                return View(hOADONs.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["username"] != null)
            {
                HOADON hOADON = db.HOADONs.Find(id);

                return View(hOADON);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
           
        }

        // GET: Admin/Order/Create
        public ActionResult Create()
        {
            ViewBag.khachhang = new SelectList(db.TAIKHOANs, "tendangnhap", "matkhau");
            return View();
        }

        // POST: Admin/Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sohd,khachhang,trigia,ngaythanhtoan")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.HOADONs.Add(hOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.khachhang = new SelectList(db.TAIKHOANs, "tendangnhap", "matkhau", hOADON.khachhang);
            return View(hOADON);
        }

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            ViewBag.khachhang = new SelectList(db.TAIKHOANs, "tendangnhap", "matkhau", hOADON.khachhang);
            return View(hOADON);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sohd,khachhang,trigia,ngaythanhtoan")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.khachhang = new SelectList(db.TAIKHOANs, "tendangnhap", "matkhau", hOADON.khachhang);
            return View(hOADON);
        }

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
       
        public ActionResult DeleteConfirmed(int id)
        {
            HOADON hOADON = db.HOADONs.Find(id);
            db.HOADONs.Remove(hOADON);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Approve(int id)
        {
            if (Session["username"] != null)
            {
                HOADON hOADON = db.HOADONs.Find(id);
                hOADON.trangthai = "shipping";
                db.SaveChanges();
                return View(hOADON);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
    }
}
