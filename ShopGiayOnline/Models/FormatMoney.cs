using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ShopGiayOnline.Models
{
    public class FormatMoney
    {
        static public String format(String money)
        {
            return string.Format(new CultureInfo("en-US"), "{0:c}", money);

        }
        static public String format(int money)
        {
            return string.Format(new CultureInfo("en-US"), "{0:c}", money);

        }
        static public String format(double money)
        {
            return string.Format(new CultureInfo("en-US"), "{0:c}", money);

        }
        static public String format(decimal money)
        {
            return string.Format(new CultureInfo("en-US"), "{0:c}", money);

        }

    }
}