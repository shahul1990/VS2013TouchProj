using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Restaurant_Amb_1.Models
{
    public class OrderOnline
    {
        HotTouchRestEntities dbcon = new HotTouchRestEntities();
        
        public DbSet<Pickup_Tbl> GetRecords()
        {
            return dbcon.Set<Pickup_Tbl>();
        }
    }
}