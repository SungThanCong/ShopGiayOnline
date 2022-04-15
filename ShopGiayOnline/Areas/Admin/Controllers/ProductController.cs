using ShopGiayOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopGiayOnline.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        SHOPGIAYEntities db = new SHOPGIAYEntities();
       
        // GET: Admin/Product
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return View(db.GIAYs.OrderBy(item => item.C_id).ToList());
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
           
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(string id)
        {
            if (Session["username"] != null)
            {
                return View(db.GIAYs.Find(id));
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

           
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
          
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                GIAY giay = new GIAY();
                giay.magiay = collection["magiay"];
                giay.gioitinh = collection["gioitinh"];
                giay.tengiay = collection["tengiay"];
                giay.soluong = int.Parse(collection["soluong"]);
                giay.hang = collection["hang"];
                giay.size = int.Parse(collection["size"]);
                giay.chitiet = collection["chitiet"];
                giay.gia = decimal.Parse(collection["gia"]);
                db.GIAYs.Add(giay);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["username"] != null)
            { 
                if(db.GIAYs.Find(id)!= null)
                {
                    return View(db.GIAYs.Find(id));
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

            
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(GIAY upd)
        {
            try
            {
                // TODO: Add update logic here
                //GIAY giay = db.GIAYs.Find(id);
              
                //giay.gioitinh = collection["gioitinh"];
                //giay.tengiay = collection["tengiay"];
                //giay.soluong = int.Parse(collection["soluong"]);
                //giay.hang = collection["hang"];
                //giay.size = int.Parse(collection["size"]);
                //giay.chitiet = collection["chitiet"];
                //giay.gia = decimal.Parse(collection["gia"]);

                var giay = db.GIAYs.Where(s => s.magiay == upd.magiay).ToList();
                foreach (var item in giay)
                {
                    item.gioitinh = upd.gioitinh;
                    item.tengiay = upd.tengiay;
                    item.soluong = upd.soluong;
                    item.hang = upd.hang;
                    item.size = upd.size;
                    item.chitiet = upd.chitiet;
                    item.gia = upd.gia;
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["username"] != null)
            {
                return View(db.GIAYs.Find(id));
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
          
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                GIAY giay = db.GIAYs.Find(id);
                db.GIAYs.Remove(giay);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
