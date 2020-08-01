using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.Entities.Inventory
{
    public class InventoryItem : BaseProperties
    {
        public string PartName { get; set; }

        public string PartNumber { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        [AllowHtml]
        public string Contents { get; set; }
        public byte[] Image { get; set; }

        public string ImageName { get; set; }

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