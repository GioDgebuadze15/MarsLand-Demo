using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebSite.Cores;

namespace WebSite.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base()
        {
            Chats = new List<ChatUser>();
            FriendShips = new List<FriendUser>();
            Posts = new List<Post>();
        }
        public ICollection<ChatUser> Chats { get; set; }

        public ICollection<FriendUser> FriendShips { get; set; }

        public ICollection<Post> Posts { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}
