using EasyCRM.Entities.Inventory;
using EasyCRM.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.ViewModels.Employees
{
    public class EmployeeIndexViewModel : BasePropertiesViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AddressCreateViewModel Address { get; set; }

        public string Phone { get; set; }

        public string EmergencyContactPerson { get; set; }

        public string EmergencyContactPersonPhone { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfJoining { get; set; }

        public DateTime DateOfLeaving { get; set; }

        public int Gender { get; set; }

        public string Password { get; set; }
    }


}