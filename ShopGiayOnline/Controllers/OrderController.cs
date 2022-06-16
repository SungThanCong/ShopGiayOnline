using ShopGiayOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopGiayOnline.Controllers
{
    public class OrderController : Controller
    {
        SHOPGIAYEntities db = new SHOPGIAYEntities();
        // GET: Order
        public ActionResult Index()
        {
            if(Session["username"] != null && Session["type"].ToString().Equals("user"))
            {
                string tenDangNhap= Session["username"].ToString();
                List<HOADON> dsHoaDon = db.HOADONs.Where(x => x.khachhang == tenDangNhap).ToList();
                List<OrderItem> dsOrder = new List<OrderItem>();
               

                foreach(var hoaDon in dsHoaDon)
                {
                    List<CartItem> dsItem = new List<CartItem>();
                    foreach (var cthd in hoaDon.CTHDs)
                    {
                        CartItem icart = new CartItem();
                        icart.Giay = db.GIAYs.Find(cthd.magiay);
                        icart.Quantity = cthd.soluong.Value;
                        icart.Size = cthd.size;
                        dsItem.Add(icart);
                    }
                    OrderItem newOrder = new OrderItem();
                    newOrder.ListCartItem = dsItem;
                    newOrder.Order = hoaDon;
                    dsOrder.Add(newOrder);

                }
                return View(dsOrder.OrderByDescending(s=>s.Order.ngaythanhtoan));
            }else
                return RedirectToAction("SignInUp", "User");
        }

        [HttpPost]
        public void CancelOrder(int sohd)
        {
            try
            {
                HOADON hoadon = db.HOADONs.Find(sohd);
                hoadon.trangthai = "cancel";
                db.SaveChanges();
            }
            catch(Exception e)
            {

            }
        }

        public ActionResult Cart()
        {
            return View();
        }
   
        public ActionResult ReOrder(int sohd)
        {
            try
            {
                foreach (var cthd in db.CTHDs.Where(s => s.sohd == sohd).ToList())
                {
                    var maGiay = cthd.magiay;
                    var size = cthd.size;
                    var soLuong = cthd.soluong.Value;

                    var cart = Session["cart"];
                    if (cart != null)
                    {
                        var list = (List<CartItem>)cart;
                        if (list.Exists(x => (x.Giay.magiay == maGiay && x.Size == size)))
                        {
                            var update = list.Find(x => x.Giay.magiay == maGiay && x.Size == size);
                            update.Quantity += soLuong;
                        }
                        else
                        {
                            CartItem item = new CartItem();
                            item.Giay = db.GIAYs.Find(maGiay);
                            item.Quantity = soLuong;
                            item.Size = size;
                            list.Add(item);
                        }
                        Session["cart"] = list;
                    }
                    else
                    {
                        CartItem item = new CartItem();
                        item.Giay = item.Giay = db.GIAYs.Find(maGiay);
                        item.Quantity = soLuong;
                        item.Size = size;

                        List<CartItem> listItem = new List<CartItem>();
                        listItem.Add(item);
                        Session["cart"] = listItem;
                    }

                }
                return RedirectToAction("Cart");
            }

            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult ReviewOrder(int sohd)
        {
            HOADON hoadon = db.HOADONs.Find(sohd);
            return View(hoadon);
        }
        
        [HttpPost]
        public void AddReview(int magiay, int sosao, string binhluan, int sohd)
        {
            try
            {
                var username = Session["username"].ToString();
                BINHLUAN binhLuan = new BINHLUAN();

                binhLuan.magiay = magiay;
                binhLuan.taikhoan = username;
                binhLuan.thoigian = DateTime.Now;
                binhLuan.binhluan1 = binhluan;

                db.BINHLUANs.Add(binhLuan);

                DANHGIA danhgia = new DANHGIA();
                danhgia.magiay = magiay;
                danhgia.taikhoan = username;
                danhgia.sosao = sosao;
                danhgia.sohd = sohd;

                db.DANHGIAs.Add(danhgia);

                db.SaveChanges();

            }
            catch (Exception e)
            {
            }
        }
    }
}