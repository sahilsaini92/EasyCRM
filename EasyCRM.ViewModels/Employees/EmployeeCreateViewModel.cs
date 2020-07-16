using EasyCRM.Entities.Settings;
using EasyCRM.ViewModels.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyCRM.ViewModels.Employees
{
    public class EmployeeCreateViewModel : BasePropertiesViewModel
    {
        [Required(ErrorMessage = "First Name required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        //public AddressCreateViewModel Address { get; set; }        

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

        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]

        public DateTime DateOfBirth { get; set; }

        [DisplayName("Date Of Joining")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]

        public DateTime DateOfJoining { get; set; }

        [DisplayName("Date Of Leaving")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        public DateTime DateOfLeaving { get; set; }

        public int Gender { get; set; }

        public string Password { get; set; }



    }
}