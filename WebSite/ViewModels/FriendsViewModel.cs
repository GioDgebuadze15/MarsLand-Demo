using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.ViewModels
{
    public class FriendsViewModel
    {
        public FriendsViewModel()
        {
            FriendsList = new List<FriendsList>();
        }
        public List<FriendsList> FriendsList { get; set; }
    }
}
