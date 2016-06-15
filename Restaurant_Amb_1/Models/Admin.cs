using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Restaurant_Amb_1.Models
{
    public class Admin
    {
    }

    public class MenuDataModel
    {
        HotTouchRestEntities menuentity = new HotTouchRestEntities();
        public DbSet<Item_Tbl> GetRecords()
        {
            return menuentity.Set<Item_Tbl>();
        }
    }

    public class PickupDataModel
    {
        HotTouchRestEntities pickupentity = new HotTouchRestEntities();
        public DbSet<Pickup_Tbl> GetRecords()
        {
            return pickupentity.Set<Pickup_Tbl>();
        }
    }
}