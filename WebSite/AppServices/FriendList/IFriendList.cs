using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.AppServices.FriendList
{
    public interface IFriendList
    {
        List<FriendUser> FriendsListOutput(string userId);

    }
}
