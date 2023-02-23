using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Enums;
using WebSite.Models;

namespace WebSite.Cores
{
    public class FriendUser
    {
        public string UserId { get; set; }

        public AppUser User { get; set; }

        public int FriendRequestId { get; set; }

        public FriendRequests FriendRequest { get; set; }

        public FriendRequestRoleEnum Role { get; set; }

        
    }
}
