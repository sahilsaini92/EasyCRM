using EasyCRM.Entities.Employees;
using EasyCRM.Entities.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyCRM.ViewModels.Sales
{
    public class ServiceCreateViewModel : BasePropertiesViewModel
    {
        [Required(ErrorMessage = "First Name required")]
        public string SNo { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        public Employee ServicedBy { get; set; }

        public DateTime ServiceDate { get; set; }

        public DateTime NextServiceDate { get; set; }

        public int NumberOfServiceDone { get; set; }

        public string Notes { get; set; }

        public List<LineItems> LineItems { get; set; }


    }
}