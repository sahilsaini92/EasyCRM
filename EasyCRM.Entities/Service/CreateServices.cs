using EasyCRM.Entities.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyCRM.Entities.Service
{
    public class CreateServices : BaseProperties
    {
        private List<CreateLineItems> _items;
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

        [Required(ErrorMessage = "Serviced By required")]
        public Employee ServicedBy { get; set; }

        public DateTime ServiceDate { get; set; }

        public string Notes { get; set; }

        public List<CreateLineItems> LineItems
        {
            get
            {
                return _items;
            }
            set
            {
                _items = new List<CreateLineItems>();
            }
        }


    }
}