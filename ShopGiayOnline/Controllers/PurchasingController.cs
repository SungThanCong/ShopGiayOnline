using ShopGiayOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopGiayOnline.Controllers
{
    public class PurchasingController : Controller
    {
        SHOPGIAYEntities db = new SHOPGIAYEntities();
        private const string SESSIONCART = "cart";
        // GET: Purchasing
        public ActionResult Index()
        {  
            if(Session["username"] != null && Session["type"].ToString().Equals("user"))
            {
                TAIKHOAN user = db.TAIKHOANs.Find(Session["username"].ToString());
                return View(user);
            }
            return View();
        }

        public ActionResult Payment(FormCollection form)
        {
            ViewBag.form = form;
            Payment statePay = new Payment();
            statePay.Phone = form["phone"];
            statePay.Email = form["email"];
            statePay.Fullname = form["fullname"];
            statePay.Country = form["country"];
            statePay.City = form["city"];
            statePay.Address = form["address"];
            statePay.Apartment = form["apartment"];
            statePay.ZipCode = form["zip"];
            Session["payment"] = statePay;

            return View();
        }
        //Cart
       
        public ActionResult AddItemToCart(int maGiay, int soLuong) 
        {
            var cart = Session[SESSIONCART];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x => x.Giay.magiay == maGiay))
                {
                    var update = list.Find(x => x.Giay.magiay == maGiay);
                    update.Quantity += soLuong;
                }
                else
                {
                    CartItem item = new CartItem();
                    item.Giay = db.GIAYs.Find(maGiay);
                    item.Quantity = soLuong;
                    list.Add(item);
                }
                Session[SESSIONCART] = list;
            }
            else
            {
                CartItem item = new CartItem();
                item.Giay = item.Giay = db.GIAYs.Find(maGiay); 
                item.Quantity = soLuong;
                
                List<CartItem> listItem = new List<CartItem>();
                listItem.Add(item);
                Session[SESSIONCART] = listItem;
            }
           
            return RedirectToAction("Index", "Collection");
        }

        [HttpPost]
        public void AddItemToCartItem(int maGiay, int soLuong)
        {
            var cart = Session[SESSIONCART];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Giay.magiay == maGiay))
                {
                    var update = list.Find(x => x.Giay.magiay == maGiay);
                    if(update.Quantity + soLuong >= 0)
                        update.Quantity += soLuong;
                    else
                    {
                        update.Quantity = 0;
                    }
                }
                Session[SESSIONCART] = list;
            }
           
        }

        [HttpPost]
        public void RemoveItemFromCart(int maGiay)
        {
            var cart = Session[SESSIONCART];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Giay.magiay == maGiay))
                {
                    var update = list.Find(x => x.Giay.magiay == maGiay);
                    
                    if(update != null)
                    {
                        list.Remove(update);
                    }
                }
               
                Session[SESSIONCART] = list;
            }
        }

        [HttpPost]
        public ActionResult PaymentLaterAction()
        {
            HOADON hoaDonMoi = new HOADON();
            Payment thongTin = (Payment)Session["payment"];
            List<CartItem> listItemPay = (List<CartItem>)Session["cart"];

            if(thongTin != null)
            {
                hoaDonMoi.sdtlh = thongTin.Phone;
                hoaDonMoi.emaillh = thongTin.Email;
                hoaDonMoi.tennguoinhan = thongTin.Fullname;
                hoaDonMoi.dcgiaohang = thongTin.Apartment + " - " + thongTin.Address + " - " + thongTin.City + " - " + thongTin.Country;
                hoaDonMoi.trangthai = "pending";
                hoaDonMoi.trangthaithanhtoan = false;
                hoaDonMoi.zipcode = thongTin.ZipCode;
                hoaDonMoi.TAIKHOAN = (TAIKHOAN)(db.TAIKHOANs.Find(Session["username"]));
                hoaDonMoi.trigia = 0;
                hoaDonMoi.ngaythanhtoan = DateTime.Now;
                db.HOADONs.Add(hoaDonMoi);
                db.SaveChanges();

                foreach (var item in listItemPay)
                {
                    CTHD cthdMoi = new CTHD();
                    cthdMoi.magiay = item.Giay.magiay;
                    cthdMoi.soluong = item.Quantity;
                    cthdMoi.sohd = hoaDonMoi.sohd;
                    db.CTHDs.Add(cthdMoi);
                    GIAY findGIay = db.GIAYs.Find(cthdMoi.GIAY.magiay);
                    findGIay.soluong -= cthdMoi.soluong;
                    db.SaveChanges();
                }

                Session["cart"] = null;
                string status = "completed";
                return RedirectToAction("PaymentResult", new { status = status });

            }
            else
            {
                string status = "failed";
                return RedirectToAction("PaymentResult", new { status = status });
            }
        }
        public ActionResult PaymentResult(string status)
        {     
            ViewBag.status = status;
            return View(); 
        }
    }
}