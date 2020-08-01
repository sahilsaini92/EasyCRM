using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyCRM.Entities.Service
{
    public class CreateLineItems : BaseProperties
    {
        public string PartNo { get; set; }

        public string Description { get; set; }

        public string Rate { get; set; }

        public string Quantity { get; set; }

        public string Amount { get; set; }

        public LineItemType LineItemType { get; set; }

        public int InventoryItemID { get; set; }

        public decimal Discount { get; set; }   

    }

    public enum LineItemType
    {
        InventoryItem = 0,
        General = 1
    }
}