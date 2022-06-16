using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopGiayOnline.Models
{
    public class OrderItem
    {
        public List<CartItem> ListCartItem { get; set; }
        public HOADON Order { get; set; }
    }
}