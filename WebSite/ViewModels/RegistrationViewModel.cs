using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;
using WebSite.Enums;

namespace WebSite.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string RegPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("RegPassword")]
        public string ConfirmPassword { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public GenderEnum? Gender { get; set; }

        public CountryEnum? Country { get; set; }

        public string IpAddress { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
