﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant_Amb_1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotTouchRestEntities2 : DbContext
    {
        public HotTouchRestEntities2()
            : base("name=HotTouchRestEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin_Tbl> Admin_Tbl { get; set; }
        public virtual DbSet<Category_Tbl> Category_Tbl { get; set; }
        public virtual DbSet<Employee_Tbl> Employee_Tbl { get; set; }
        public virtual DbSet<HomeDelivery_Tbl> HomeDelivery_Tbl { get; set; }
        public virtual DbSet<Item_Tbl> Item_Tbl { get; set; }
        public virtual DbSet<Itemtype_Tbl> Itemtype_Tbl { get; set; }
        public virtual DbSet<Pickup_Tbl> Pickup_Tbl { get; set; }
    }
}
