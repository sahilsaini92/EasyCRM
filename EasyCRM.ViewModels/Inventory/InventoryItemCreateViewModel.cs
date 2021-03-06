﻿using EasyCRM.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.ViewModels.Inventory
{
    public class InventoryItemCreateViewModel : BasePropertiesViewModel
    {
        [DisplayName("Part Name")]
        [Required(ErrorMessage = "Part Name is required")]
        public string PartName { get; set; }

        [DisplayName("Part Number")]
        [Required(ErrorMessage = "Part Number is required")]
        public string PartNumber { get; set; }

        public SelectList SourceList { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [AllowHtml]
        public string Contents { get; set; }
        public byte[] Image { get; set; }

        public string ImageName { get; set; }

        public string ImageUrl { get; set; }

    }


}