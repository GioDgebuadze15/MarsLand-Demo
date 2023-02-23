using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebSite.Enums;

namespace WebSite.Models
{
    public class MailVerificationModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string SentCode { get; set; }

        public int? WrittenCode { get; set; }

        public MailVerificationPurposeEnum Puropse { get; set; }

        
    }
}
