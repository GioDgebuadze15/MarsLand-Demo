using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.OData.Edm;
using WebSite.Enums;
using WebSite.Models;

namespace WebSite.Cores
{
    public class UserInfo
    {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        public AppUser User { get; set; }

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

        [Required]
        public AccountStatusEnum AccountStatus { get; set; }

        public ProfileImageModel ProfileImage { get; set; }
        public CoverImageModel CoverImage { get; set; }
        public Bio Bio { get; set; }


        public Date GetShortDate()
        {
            if (DateOfBirth == null)
            {
                return new Date();
            }
            return (Date)DateOfBirth;
        }
    }
}
