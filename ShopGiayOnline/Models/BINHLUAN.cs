//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopGiayOnline.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BINHLUAN
    {
        public int C_id { get; set; }
        public int magiay { get; set; }
        public string taikhoan { get; set; }
        public string binhluan1 { get; set; }
        public Nullable<System.DateTime> thoigian { get; set; }
    
        public virtual GIAY GIAY { get; set; }
        public virtual TAIKHOAN TAIKHOAN1 { get; set; }
    }
}
