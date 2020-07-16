using EasyCRM.Entities.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyCRM.Entities.Sales
{
    public class Customer : BaseProperties
    {
        [Required(ErrorMessage = "Customer Name required")]
        public string CustomerName { get; set; }

        public Address Address { get; set; }

        public string VehicleNumber { get; set; }

        public string Model { get; set; }

        public string PhoneNumber { get; set; }

        public string VM { get; set; }

    }


}