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
    public class InventoryItemCreateViewModel : BasePropertiesViewModel
    {
        [DisplayName("Part Name")]
        [Required(ErrorMessage = "Part Name is required")]
        public string PartName { get; set; }

        [DisplayName("Part Number")]
        [Required(ErrorMessage = "Part Number is required")]
        public string PartNumber { get; set; }

        public SelectList SourceList { get; set; }

    }


}