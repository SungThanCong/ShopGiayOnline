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
    
    public partial class HOADON
    {
        public HOADON()
        {
            this.CTHDs = new HashSet<CTHD>();
            this.DANHGIAs = new HashSet<DANHGIA>();
        }
    
        public int sohd { get; set; }
        public string khachhang { get; set; }
        public Nullable<decimal> trigia { get; set; }
        public Nullable<System.DateTime> ngaythanhtoan { get; set; }
        public string trangthai { get; set; }
        public string phanhoi { get; set; }
        public string dcgiaohang { get; set; }
        public string tennguoinhan { get; set; }
        public string sdtlh { get; set; }
        public string emaillh { get; set; }
        public Nullable<bool> trangthaithanhtoan { get; set; }
        public string zipcode { get; set; }
    
        public virtual TAIKHOAN TAIKHOAN { get; set; }
        public virtual ICollection<CTHD> CTHDs { get; set; }
        public virtual ICollection<DANHGIA> DANHGIAs { get; set; }
    }
}
