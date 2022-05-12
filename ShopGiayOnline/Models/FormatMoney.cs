using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopGiayOnline.Models
{
    public class FormatMoney
    {
        static public String format(String money)
        {
           return String.Format("{0:0,0}",money);
        }
        static public String format(int money)
        {
            return String.Format("{0:0,0}", money);
        }
        static public String format(double money)
        {
            return String.Format("{0:0,0}", money);
        }
        static public String format(decimal money)
        {
            return String.Format("{0:0,0}", money);
        }

    }
}