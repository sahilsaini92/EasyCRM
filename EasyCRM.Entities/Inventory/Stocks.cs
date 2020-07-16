using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyCRM.Entities.Inventory
{
    public class Stocks : BaseProperties
    {
        public int ItemID { get; set; }

        public InventoryItem Item { get; set; }

        public Source From { get; set; }

        public Source To { get; set; }

        public string RackNumber { get; set; }

        public int WarehouseStock { get; set; }

        public int ServiceStationStock { get; set; }

        public int Price { get; set; }

        public int SalePrice { get; set; }
    }

}