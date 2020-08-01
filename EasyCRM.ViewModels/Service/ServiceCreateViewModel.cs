using EasyCRM.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.ViewModels.Service
{
    public class ServiceCreateViewModel : BasePropertiesViewModel
    {
        private List<ServiceCreateItemsViewModel> _items;
        public DateTime ServiceDate { get; set; }

        public string BillNo { get; set; }

        [DisplayName("Model")]
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

        public string Description { get; set; }

        [DisplayName("Vehicle Number")]
        [Required(ErrorMessage = "VehicleNumber is required")]
        public string VehicleNumber { get; set; }

        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        public string Country { get; set; }

        public string PinCode { get; set; }

        public decimal TotalValue { get; set; }

        public QuoteItemViewModel Items { get; set; }

    }


}