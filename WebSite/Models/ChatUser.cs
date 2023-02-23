using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class ChatUser
    {
        public string UserId { get; set; }

        public AppUser User { get; set; }

        public int ChatId { get; set; }

        public Chat Chat { get; set; }

        public UserRole Role { get; set; }
    }
}
