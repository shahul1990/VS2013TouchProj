using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Restaurant_Amb_1.Models
{
    public class ItemModel
    {
        
        public int itemid { get; set; }
        [Required, DisplayName("Item Name")]
        public string iname { get; set; }
        [Required, DisplayName("Description")]
        public string idesc { get; set; }
        [Required, DisplayName("Item Type")]
        public string itype { get; set; }
        [DisplayName("Item Image")]
        public byte[] iimage { get; set; }
        [Required, DisplayName("Price")]
        public decimal iprice { get; set; }
        [Required, DisplayName("Category")]
        public string icategory { get; set; }
        [Required, DisplayName("Created By")]
        public string createdby { get; set; }
        [Required, DisplayName("Created Date")]
        public System.DateTime createddate { get; set; }
        [DisplayName("Updated By")]
        public string updatedby { get; set; }
        [DisplayName("Update Date")]
        public Nullable<System.DateTime> updateddate { get; set; }
    }
}