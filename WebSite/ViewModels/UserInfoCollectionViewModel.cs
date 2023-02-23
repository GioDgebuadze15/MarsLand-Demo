using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebSite.Cores;
using WebSite.Models;
using WebSite.Models.Comments;

namespace WebSite.ViewModels
{
    public class UserInfoCollectionViewModel
    {
        public UserInfoCollectionViewModel()
        {
            FriendsViewModel = new FriendsViewModel();
        }
        public AppUser AppUser { get; set; } 

        public List<FriendUser> FriendsList { get; set; }
        public List<UserInfo> FindPeople { get; set; }
        public List<FriendRequests> FriendRequests { get; set; }
        public FriendsViewModel FriendsViewModel { get; set; }

        public UserInfo EditProfileInfo { get; set; }

        public UserInfoViewModel UserInfoView { get; set; } 
        public List<UserInfo> AllUserInfoView { get; set; }

        public List<Post> FriendsPosts { get; set; }
        public PostViewModel PostViewModel { get; set; }
        public CommentViewModel CommentViewModel { get; set; }

        public ProfileImageModel ProfileImage { get; set; }
        public CoverImageModel CoverImage { get; set; }
    }
}
