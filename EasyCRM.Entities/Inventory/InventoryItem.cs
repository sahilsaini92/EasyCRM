using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyCRM.Entities.Inventory
{
    public class InventoryItem : BaseProperties
    {
        public string PartName { get; set; }

        public string PartNumber { get; set; }

    }

    public enum Source
    {
        
        [Display(Name = "WareHouse")]
        WareHouse = 0,

        [Display(Name = "Service Station")]
        ServiceStation = 1,

        [Display(Name = "Supplier")]
        Supplier = 2
    }
}