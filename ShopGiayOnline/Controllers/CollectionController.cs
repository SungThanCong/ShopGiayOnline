﻿using PagedList;
using ShopGiayOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopGiayOnline.Controllers
{
    public class CollectionController : Controller
    {
        SHOPGIAYEntities db = new SHOPGIAYEntities();
        // GET: Collection
        class GiayProperties
        {
            public GiayProperties()
            {
                IMAGES = new List<string>();
                SALEOFFs = new List<int>();
            }
            public int magiay { get; set; }
            public string tengiay { get; set; }
            public string gioitinh { get; set; }
            public Nullable<int> size { get; set; }
            public Nullable<int> soluong { get; set; }
            public string hang { get; set; }
            public string hinh { get; set; }
            public string chitiet { get; set; }
            public Nullable<decimal> gia { get; set; }
            public Nullable<int> danhgia { get; set; }
            public Nullable<int> soluotdanhgia { get; set; }

            public List<string> IMAGES { get; set; }
            public List<int> SALEOFFs { get; set; }
        }
        public ActionResult Index(int? page)
        {
            var links = db.GIAYs.OrderBy(s => s.magiay);
           

            int pageNumber = (page ?? 1);

            var listItem = links.ToList();
            List<GiayProperties> listGiay = new List<GiayProperties>();
            foreach(var item in listItem)
            {
                GiayProperties giay = new GiayProperties();
                giay.magiay = item.magiay;
                giay.tengiay = item.tengiay;
                giay.gioitinh = item.gioitinh;
                giay.size = item.size;
                giay.hang = item.hang;
                giay.hinh = item.hinh;
                giay.chitiet = item.chitiet;
                giay.gia = item.gia;
                giay.danhgia = item.danhgia;
                giay.soluotdanhgia = item.soluotdanhgia;
               
                foreach(var i in item.IMAGES){
                    giay.IMAGES.Add(i.image_url);
                }
                foreach(var i in item.SALEOFFs)
                {
                    if(i.ngaybatdau < DateTime.Today && i.ngayketthuc > DateTime.Today)
                    {
                        giay.SALEOFFs.Add(i.giamgia.Value);
                    }
                }

                listGiay.Add(giay);
            }
            ViewBag.listItem = listGiay;

            return View(links.ToPagedList(pageNumber,9));
        }


        public ActionResult Item(int id)
        {
            GIAY giay = db.GIAYs.Find(id);
            return View(giay);
        }
    }
}