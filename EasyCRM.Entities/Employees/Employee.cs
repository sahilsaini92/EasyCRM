using EasyCRM.Entities.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyCRM.Entities.Employees
{
    public class Employee : BaseProperties
    {
        [Required(ErrorMessage = "First Name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; }

        public Address Address { get; set; }        

        [Required(ErrorMessage = "Telephone required")]
        [DisplayName("Telephone")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Contact person required")]
        [DisplayName("Contact person")]
        public string EmergencyContactPerson { get; set; }

        [Required(ErrorMessage = "Contact person Phone required")]
        [DisplayName("Contact person phone")]
        public string EmergencyContactPersonPhone { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfJoining { get; set; }

        public DateTime DateOfLeaving { get; set; }

        public int Gender { get; set; }

    }
}