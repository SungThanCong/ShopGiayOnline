using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopGiayOnline.Models
{
    public class ThongKeTongHop
    {
        public List<ThongKeTheoQuocGia> ThongKeTheoQuocGias { get; set; }
        public List<ThongKeTopSale> ThongKeTopSales { get; set; }
    }
}