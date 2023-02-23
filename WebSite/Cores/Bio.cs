using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Cores
{
    public class Bio
    {
        [Key, ForeignKey("UserInfo")]
        public string UserId { get; set; }

        public UserInfo UserInfo { get; set; }

        public string Text { get; set; }
    }
}
