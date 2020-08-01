using EasyCRM.Entities.Inventory;
using EasyCRM.Entities.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.ViewModels.Service
{
    public class ServiceCreateItemsViewModel
    {

        public int ID { get; set; }

        [DisplayName("Part Name")]
        [Required(ErrorMessage = "Part Name is required")]
        public string PartName { get; set; }

        [DisplayName("Line Item Type")]
        [Required(ErrorMessage = "Line Item Type is required")]
        public LineItemType LineItemType { get; set; }

        [DisplayName("Part Number")]
        [Required(ErrorMessage = "Part Number is required")]
        public string PartNumber { get; set; }

        public SelectList LineItemTypes { get; set; }

        public SelectList Items { get; set; }

        public string Description { get; set; }

        public decimal Rate { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal Quantity { get; set; }

        public decimal Discount { get; set; }

    }

}