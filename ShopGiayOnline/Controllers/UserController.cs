using ShopGiayOnline.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopGiayOnline.Controllers
{
    public class UserController : Controller
    {
        SHOPGIAYEntities db = new SHOPGIAYEntities();
        // GET: User
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {   
                if(Session["type"].Equals("user"))
                {
                    string username = Session["username"].ToString();
                    TAIKHOAN dangNhap = db.TAIKHOANs.Find(username);
                    ViewBag.Type = "profile";
                    return View(dangNhap);
                }
               
            }
            return RedirectToAction("SignInUp");        
        }

        public ActionResult SignInUp()
        {
            return View();
        }

        public ActionResult SignIn(string tendangnhap, string matkhau)
        {
            if (ModelState.IsValid)
            {
                var data = db.TAIKHOANs.Where(s => s.tendangnhap.Equals(tendangnhap) && s.matkhau.Equals(matkhau)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["username"] = data.FirstOrDefault().tendangnhap;
                    Session["password"] = data.FirstOrDefault().matkhau;
                    Session["type"] = "user";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                }
            }
            return RedirectToAction("SignInUp");
        }
        public ActionResult SignUp(TAIKHOAN taiKhoan)
        {
            try
            {
                TAIKHOAN tk = new TAIKHOAN();
                tk.hoten = taiKhoan.hoten;
                tk.tendangnhap = taiKhoan.tendangnhap;
                tk.matkhau = taiKhoan.matkhau;
                tk.email = taiKhoan.email;
                tk.sdt = taiKhoan.sdt;
                tk.ngaydk = DateTime.Now.Date;
                tk.doanhthu = 0;

                db.TAIKHOANs.Add(tk);
                
                db.SaveChanges();
                ViewBag.Complete = "Sign up completed";
                return RedirectToAction("SignInUp");

            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("SignInUp");
            }
            
        }
        [HttpPost]
        public ActionResult UpdateProfile( HttpPostedFileBase file, TAIKHOAN update)
        {

            try
            {
                string tendangnhap = update.tendangnhap;
                TAIKHOAN taikhoan = db.TAIKHOANs.Find(tendangnhap);

                taikhoan.hoten = update.hoten;
                taikhoan.gioitinh = update.gioitinh;
                taikhoan.email = update.email;
                taikhoan.quoctich = update.quoctich;
                taikhoan.sdt = update.sdt;
                taikhoan.ngaysinh = update.ngaysinh;
                taikhoan.diachi = update.diachi;
                
              
                    var fileName = Path.GetFileName(file.FileName);
                    var ext = Path.GetExtension(file.FileName);
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    string myfile = "avatar_" + tendangnhap + ext; //appending the name with id  
                                                        // store the file inside ~/project folder(Img)  
                    var path = "~/Source/" + myfile;
                    var path2 = Path.Combine(Server.MapPath("~/Source"), myfile);

                    var path_del = Server.MapPath(taikhoan.avatar);
                    FileInfo file2 = new FileInfo(path_del);
                    if (file2.Exists)//check file exsit or not  
                    {
                        file2.Delete();
                    }
                    taikhoan.avatar = path;
                    file.SaveAs(path2);
              
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            catch(Exception e)
            {
                ViewBag.error = e.Message;
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public ActionResult ChangePassword(string currentPassword, string newPassword, string reNewPassword)
        {
            string username = Session["username"].ToString();
            TAIKHOAN dangNhap = db.TAIKHOANs.Find(username);
            if (currentPassword.Length > 0 && newPassword.Length >0 && reNewPassword.Length > 0)
            {
                if (dangNhap.matkhau.Equals(currentPassword))
                {
                    if (newPassword.Equals(reNewPassword))
                    {
                        dangNhap.matkhau = newPassword;
                        db.SaveChanges();
                        ViewBag.status = "Change password successful";
                        ViewBag.type = "password";
                        ViewBag.success = "true";
                        return View("Index", dangNhap);
                    }
                    else
                    {
                        ViewBag.status = "Confirm password not match";
                        ViewBag.type = "password";
                        return View("Index", dangNhap);
                    }
                }
                else
                {
                    ViewBag.status = "Current password is not true";
                    ViewBag.type = "password";
                    return View("Index", dangNhap);
                }
            }
            else
            {
                ViewBag.status= "Please enter full";
                ViewBag.type = "password";
                return View("Index",dangNhap);
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("SignInUp");
        }
    }
}