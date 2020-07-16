using EasyCRM.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.ViewModels.Inventory
{
    public class InventoryItemIndexViewModel : BasePropertiesViewModel
    {
        public string PartName { get; set; }

        public string PartNumber { get; set; }

        public Source Source { get; set; }

        public SelectList SourceList { get; set; }

        public string RackNumber { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int SalePrice { get; set; }
    }


}