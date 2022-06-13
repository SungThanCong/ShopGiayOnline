using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopGiayOnline.Models
{
    [Serializable]
    public class CartItem
    {
        public GIAY Giay { get; set; }
        public int Quantity { get; set; }
    }
}