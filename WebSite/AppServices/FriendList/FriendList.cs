using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebSite.Cores;
using WebSite.Models;
using WebSite.EntityFramework.DbContext;
using WebSite.ViewModels;
using WebSite.Enums;
using Microsoft.EntityFrameworkCore;

namespace WebSite.AppServices.FriendList
{
    public class FriendList : IFriendList
    {
        private readonly AppDbContext _regRepository;
        private readonly UserManager<AppUser> _userManager;

        public FriendList(AppDbContext regRepository, UserManager<AppUser> userManager)
        {
            _regRepository = regRepository;
            _userManager = userManager;
        }


        public List<FriendUser> FriendsListOutput(string userId)
        {
            var friends = _regRepository.FriendRequests.Where(x => x.FriendStatus == FriendRequestEnum.Approved && x.FriendUsers.Any(y => y.UserId == userId))
                    .Include(x => x.FriendUsers)
                    .ThenInclude(x=>x.User)
                            .ThenInclude(x => x.UserInfo)
                                .ThenInclude(x => x.ProfileImage)
                    .SelectMany(x=>x.FriendUsers.Where(y=>y.UserId != userId))
                                .ToList();
            if (friends.Count == 0)
            {
                return new List<FriendUser>();
            }
            else
            {
                return friends;
            }
        }




    }
}
