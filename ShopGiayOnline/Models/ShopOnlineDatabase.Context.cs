﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SHOPGIAYEntities : DbContext
    {
        public SHOPGIAYEntities()
            : base("name=SHOPGIAYEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BANNER> BANNERs { get; set; }
        public DbSet<BINHLUAN> BINHLUANs { get; set; }
        public DbSet<CTHD> CTHDs { get; set; }
        public DbSet<GIAY> GIAYs { get; set; }
        public DbSet<HOADON> HOADONs { get; set; }
        public DbSet<SaleOff> SaleOffs { get; set; }
        public DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public DbSet<TAIKHOANCHU> TAIKHOANCHUs { get; set; }
    }
}