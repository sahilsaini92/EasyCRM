using EasyCRM.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.ViewModels.Inventory
{
    public class AddStockViewModel : BasePropertiesViewModel
    {
        [DisplayName("To")]
        [Required(ErrorMessage = "Source is required")]
        public Source To { get; set; }

        [DisplayName("From")]
        [Required(ErrorMessage = "Source is required")]
        public Source From { get; set; }

        [DisplayName("Item")]
        [Required(ErrorMessage = "Item is required")]
        public int ItemId { get; set; }

        public SelectList ItemList { get; set; }

        public SelectList SourceList { get; set; }

        public string RackNumber { get; set; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        [DisplayName("Sale Price")]
        [Required(ErrorMessage = "Sale Price is required")]
        public int SalePrice { get; set; }
    }


}