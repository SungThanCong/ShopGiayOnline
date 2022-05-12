using ShopGiayOnline.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                return View(db.GIAYs.ToList());
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
           
        }

        // GET: Admin/Product/Details/5
        //public ActionResult Details(int id)
        //{
        //    if (Session["username"] != null)
        //    {
        //        return View(db.GIAYs.Find(id));
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Home");
        //    }

           
        //}

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
        public ActionResult Create(GIAY upd, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here
                GIAY giay = new GIAY();

                var giaymax = db.GIAYs.Select(item => item).OrderByDescending(item => item.magiay).FirstOrDefault();
                int id = giaymax.magiay + 1;

                giay.gioitinh = upd.gioitinh;
                giay.tengiay = upd.tengiay;
                giay.soluong = upd.soluong;
                giay.hang = upd.hang;
                giay.size = upd.size;
                giay.chitiet = upd.chitiet;
                giay.gia = upd.gia;


                if (file != null)
                {
                    var allowedExtensions = new[] {
                    ".Jpg", ".png", ".jpg", "jpeg"
                        };
                    var fileName = Path.GetFileName(file.FileName);
                    var ext = Path.GetExtension(file.FileName);
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                        string myfile = "giay_" + id + ext; //appending the name with id  
                                                                   // store the file inside ~/project folder(Img)  
                        var path = "~/Source/" + myfile;
                        var path2 = Path.Combine(Server.MapPath("~/Source"), myfile);
                        giay.hinh = path;
                     
                        file.SaveAs(path2);
                    }
                    else
                    {
                        ViewBag.message = "Please choose only Image file";
                    }
                }
                db.GIAYs.Add(giay);
                db.SaveChanges();

               
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                   return View();
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
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
        public ActionResult Edit(GIAY upd, HttpPostedFileBase file)
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
                    int id = item.magiay;
                    item.gioitinh = upd.gioitinh;
                    item.tengiay = upd.tengiay;
                    item.soluong = upd.soluong;
                    item.hang = upd.hang;
                    item.size = upd.size;
                    item.chitiet = upd.chitiet;
                    item.gia = upd.gia;

                    if (file != null)
                    {
                        var allowedExtensions = new[] {
                    ".Jpg", ".png", ".jpg", "jpeg"
                        };
                        var fileName = Path.GetFileName(file.FileName);
                        var ext = Path.GetExtension(file.FileName);
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                            string myfile = "giay_" + id + ext; //appending the name with id  
                                                                   // store the file inside ~/project folder(Img)  
                            var path = "~/Source/" + myfile;
                            var path2 = Path.Combine(Server.MapPath("~/Source"), myfile);
                           

                            var path_del = Server.MapPath(item.hinh);
                            FileInfo file2 = new FileInfo(path_del);
                            if (file2.Exists)//check file exsit or not  
                            {
                                file2.Delete();
                            }
                            item.hinh = path;
                            file.SaveAs(path2);
                        }
                        else
                        {
                            ViewBag.message = "Please choose only Image file";
                        }
                    }
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
        public ActionResult Delete(int id)
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
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                GIAY giay = db.GIAYs.Find(id);
               
                db.GIAYs.Remove(giay);
                db.SaveChanges();

                var path = Server.MapPath(giay.hinh);
                FileInfo file = new FileInfo(path);
                if (file.Exists)//check file exsit or not  
                {
                    file.Delete();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
