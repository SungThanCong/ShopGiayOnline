using ShopGiayOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopGiayOnline.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        private SHOPGIAYEntities db = new SHOPGIAYEntities();
        public ActionResult Index()
        {
            if (Session["username"] != null && Session["type"].ToString().Equals("admin"))
            {
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                string month_year;
                if (month < 10)
                {
                    month_year = year + "-0" + month;
                }
                else
                {
                    month_year = year + "-" + month;
                }
                var kq = db.THONGKEs.Where(s => s.thang == month).Where(s => s.nam == year).FirstOrDefault();

                //tong doanh thu
                var list_hoadon = db.HOADONs.Where(s => s.ngaythanhtoan.ToString().Contains(month_year) == true).ToList();
                decimal tongTien = 0;
                foreach (var item in list_hoadon)
                {
                    tongTien += item.trigia.Value;
                }
                int tongDonHang = list_hoadon.Count;
                decimal tienTrungBinh = tongDonHang > 0 ? tongTien / tongDonHang : 0;
                int soNguoiDungMoi = db.TAIKHOANs.Where(s => s.ngaydk.ToString().Contains(month_year) == true).ToList().Count;

                if (kq == null)
                {
                    THONGKE thongKe = new THONGKE();
                    thongKe.giatritrungbinh = tienTrungBinh;
                    thongKe.nam = year;
                    thongKe.thang = month;
                    thongKe.tongdoanhthu = tongTien;
                    thongKe.tongdonhang = tongDonHang;
                    thongKe.nguoidungmoi = soNguoiDungMoi;

                    db.THONGKEs.Add(thongKe);
                }
                else
                {
                    THONGKE thongKe = kq;
                    thongKe.giatritrungbinh = tienTrungBinh;
                    thongKe.nam = year;
                    thongKe.thang = month;
                    thongKe.tongdoanhthu = tongTien;
                    thongKe.tongdonhang = tongDonHang;
                    thongKe.nguoidungmoi = soNguoiDungMoi;
                }
                db.SaveChanges();

                List<decimal> list_data = new List<decimal>();
                List<decimal> list_data_quocgia = new List<decimal>();
                List<string> list_data_tenquocgia = new List<string>();

                var list_thongKe = db.THONGKEs.Where(s => s.nam == year).OrderBy(s => s.thang).ToList();
                var list_thongKe_quocgia = db.HOADONs.Where(s => s.ngaythanhtoan.ToString().Contains(month_year) == true)
                                                    .Join(db.TAIKHOANs, p => p.khachhang, q => q.tendangnhap, (p, q) => new { quoctich = q.quoctich, doanhthu = p.trigia })
                                                    .GroupBy(s => s.quoctich)
                                                    .Select(s => new ThongKeTheoQuocGia { QuocTich = s.FirstOrDefault().quoctich, DoanhThu = s.Sum(k => k.doanhthu.Value) })
                                                    .ToList();



                var top_sale = db.HOADONs.Where(s => s.ngaythanhtoan.ToString().Contains(month_year) == true)
                                         .Join(db.CTHDs, p => p.sohd, q => q.sohd, (q, p) => new { magiay = p.magiay, soluong = p.soluong })
                                         .Join(db.GIAYs, p => p.magiay, q=> q.magiay, (q,p)=>new {magiay = p.magiay, tengiay = p.tengiay, soluong = q.soluong, hinh = p.hinh })
                                         .GroupBy(s => s.tengiay)
                                         .Select(s => new ThongKeTopSale{MaGiay = s.FirstOrDefault().magiay, ImageUrl = s.FirstOrDefault().hinh ,TenGiay = s.FirstOrDefault().tengiay, SoLuong = s.Sum(k => k.soluong.Value) })
                                         .OrderByDescending(s => s.SoLuong)
                                         .Take(10)
                                         .ToList();


                foreach (var item in list_thongKe_quocgia)
                {
                    list_data_quocgia.Add(item.DoanhThu);
                    list_data_tenquocgia.Add(item.QuocTich);
                }

                ThongKeTongHop thongKeTongHop = new ThongKeTongHop();
                thongKeTongHop.ThongKeTheoQuocGias = list_thongKe_quocgia;
                thongKeTongHop.ThongKeTopSales = top_sale;

                for (int i = 0; i < 12; i++)
                {
                    int k = 0;
                    foreach(var item in list_thongKe)
                    {
                        if(item.thang == i + 1)
                        {
                            k = 1;
                            list_data.Add(item.tongdoanhthu.Value);
                            break;
                        }
                    }
                    if (k == 0)
                    {
                        list_data.Add(0);
                    }      
                }
                ViewBag.data = list_data;
                ViewBag.tongdonhang = tongDonHang;
                ViewBag.tongdoanhthu = tongTien;
                ViewBag.nguoidungmoi = soNguoiDungMoi;
                ViewBag.trungbinh = tienTrungBinh;
                ViewBag.tongdoanhthutheoquocgia = list_data_quocgia;
                ViewBag.list_thongKe_tenquocgia = list_data_tenquocgia;
                ViewBag.so_luong_quoc_gia = list_data_tenquocgia.Count;
                ViewBag.list_thongKe_doanhthuquocgia = list_thongKe_quocgia;

                return View(thongKeTongHop);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
    }
}