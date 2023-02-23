using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;
using WebSite.Enums;

namespace WebSite.ViewModels
{
    public class UserInfoViewModel
    {
        public UserInfo UserInfo { get; set; }

        public FriendRequestEnum? FriendStatus { get; set; }

        public FriendRequestRoleEnum? Role { get; set; }

        public int? FriendRequestId { get; set; }

    }
}
