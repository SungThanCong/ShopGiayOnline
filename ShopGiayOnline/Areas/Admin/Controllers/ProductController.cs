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
        public ActionResult Create(GIAY upd, HttpPostedFileBase[] files, FormCollection form)
        {
            try
            {
                // TODO: Add insert logic here
                GIAY giay = new GIAY();
                int count_size = 0;
                if(form["size_1"].Length > 0 && form["quantity_1"].Length > 0)
                {
                    count_size = 1;
                }

                
                
                if(upd.tengiay == null)
                {
                    ViewBag.Error = "Vui lòng nhập tên giày";
                }
                else if(count_size <1)
                {
                    ViewBag.Error = "Vui lòng nhập size giày";
                }else if(!upd.gia.HasValue)
                {
                    ViewBag.Error = "Vui lòng nhập giá giày";
                }
                else
                {
                    giay.gioitinh = upd.gioitinh;
                    giay.tengiay = upd.tengiay;
                    //giay.soluong = upd.soluong;
                    giay.hang = upd.hang;
                    giay.chitiet = upd.chitiet;
                    giay.gia = upd.gia;
                    giay.danhgia = 0;
                    giay.soluotdanhgia = 0;

                    db.GIAYs.Add(giay);
                    db.SaveChanges();

                    
                    var getGiay = db.GIAYs.Select(item => item).OrderByDescending(item => item.magiay).FirstOrDefault();
                    int id = getGiay.magiay;

                    if (files != null)
                    {
                        var file = files[0];
                        if(file != null)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var ext = Path.GetExtension(file.FileName);
                            string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                            string myfile = "giay_" + id + ext; //appending the name with id  
                                                                // store the file inside ~/project folder(Img)  
                            var path = "~/Source/" + myfile;
                            var path2 = Path.Combine(Server.MapPath("~/Source"), myfile);
                            getGiay.hinh = path;
                            file.SaveAs(path2);

                            foreach (var image in files)
                            {
                                var f_name = Path.GetFileName(image.FileName);
                                var f_ext = Path.GetExtension(image.FileName);
                                string f_nameWe = Path.GetFileNameWithoutExtension(f_name);
                                string f_myfile = "giay_image_" + id + f_nameWe + f_ext;

                                var f_path = "~/Source/Product/" + f_myfile;
                                var f_path2 = Path.Combine(Server.MapPath("~/Source/Product"), f_myfile);
                                IMAGE pro_image = new IMAGE();
                                pro_image.image_url = f_path;
                                image.SaveAs(f_path2);
                                getGiay.IMAGES.Add(pro_image);

                            }
                        }     
                    }
                   

                  
                    getGiay.soluong = 0;

                    while (form["size_" + count_size] != null)
                    {
                        if (form["size_" + count_size].Length > 0 && form["quantity_" + count_size].Length > 0)
                        {
                            BANGSIZE sizeGiayMoi = new BANGSIZE();
                            sizeGiayMoi.magiay = id;
                            sizeGiayMoi.size = int.Parse(form["size_" + count_size]);
                            sizeGiayMoi.soluong = int.Parse(form["quantity_" + count_size]);
                            getGiay.soluong += sizeGiayMoi.soluong;

                            db.BANGSIZEs.Add(sizeGiayMoi);
                        }
                        count_size++;
                        
                    }
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View();
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
            if (Session["username"] != null && Session["type"].ToString().Equals("admin"))
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
        public ActionResult Edit(GIAY upd, HttpPostedFileBase[] files, FormCollection form)
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
                int count_size = 0;
                if (form["size_1"].Length > 0 && form["quantity_1"].Length > 0)
                {
                    count_size = 1;
                }

                if (upd.tengiay == null)
                {
                    ViewBag.Error = "Vui lòng nhập tên giày";
                }
                else if (count_size < 1)
                {
                    ViewBag.Error = "Vui lòng nhập size giày";
                }
                else if (!upd.gia.HasValue)
                {
                    ViewBag.Error = "Vui lòng nhập giá giày";
                }
                else
                {
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

                        if (files != null) { 
                            //save in product
                            var file = files[0];
                            if(file != null)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                var ext = Path.GetExtension(file.FileName);
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

                                //save in iamges
                                var data_image = item.IMAGES;
                                foreach (var image in data_image)
                                {
                                    var del = Server.MapPath(image.image_url);
                                    FileInfo imageDel = new FileInfo(del);
                                    if (imageDel.Exists)
                                    {
                                        imageDel.Delete();
                                    }
                                }
                                item.IMAGES.Clear();
                                db.IMAGES.RemoveRange(db.IMAGES.Where(s => s.magiay == item.magiay));
                                foreach (var image in files)
                                {
                                    var f_name = Path.GetFileName(image.FileName);
                                    var f_ext = Path.GetExtension(image.FileName);
                                    string f_nameWe = Path.GetFileNameWithoutExtension(f_name);
                                    string f_myfile = "giay_image_" + id + f_nameWe + f_ext;

                                    var f_path = "~/Source/Product/" + f_myfile;
                                    var f_path2 = Path.Combine(Server.MapPath("~/Source/Product"), f_myfile);
                                    IMAGE pro_image = new IMAGE();
                                    pro_image.image_url = f_path;
                                    image.SaveAs(f_path2);
                                    item.IMAGES.Add(pro_image);

                                }
                            }
                        }
                    }
                }
                db.SaveChanges();

                GIAY getGiay = db.GIAYs.Find(upd.magiay);
                getGiay.soluong = 0;

                db.BANGSIZEs.RemoveRange(getGiay.BANGSIZEs);

                while (form["size_" + count_size] != null)
                {
                    if (form["size_" + count_size].Length > 0 && form["quantity_" + count_size].Length > 0)
                    {
                        BANGSIZE sizeGiayMoi = new BANGSIZE();
                        sizeGiayMoi.magiay = upd.magiay;
                        sizeGiayMoi.size = int.Parse(form["size_" + count_size]);
                        sizeGiayMoi.soluong = int.Parse(form["quantity_" + count_size]);
                        getGiay.soluong += sizeGiayMoi.soluong;

                        db.BANGSIZEs.Add(sizeGiayMoi);
                    }
                    count_size++;

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

                var path = Server.MapPath(giay.hinh);
                FileInfo file = new FileInfo(path);
                if (file.Exists)//check file exsit or not  
                {
                    file.Delete();
                }

                foreach(var item in giay.IMAGES.ToList())
                {
                    var path_item = Server.MapPath(item.image_url);
                    FileInfo file_item = new FileInfo(path_item);
                    if (file_item.Exists)
                    {
                        file_item.Delete();
                    }
                    db.IMAGES.Remove(item);
                }

                db.BANGSIZEs.RemoveRange(giay.BANGSIZEs);
                db.BINHLUANs.RemoveRange(giay.BINHLUANs);
                db.CTHDs.RemoveRange(giay.CTHDs);
                
               
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
