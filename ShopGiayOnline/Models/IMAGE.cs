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
    
    public partial class IMAGE
    {
        public int id { get; set; }
        public Nullable<int> magiay { get; set; }
        public string image_url { get; set; }
    
        public virtual GIAY GIAY { get; set; }
    }
}
