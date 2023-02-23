using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;
using WebSite.Enums;

namespace WebSite.ViewModels
{
    public class ExternalRegisterViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public GenderEnum? Gender { get; set; }

        public CountryEnum? Country { get; set; }

        public List<string> Errors { get; set; }
    }
}
