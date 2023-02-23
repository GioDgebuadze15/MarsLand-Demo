using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.AppServices.Profile
{
    public interface IProfileInfo
    {
        UserInfoCollectionViewModel ProfileInfoOutput(string id, string username);
        UserInfoCollectionViewModel UserInfoOutput(string id, string username);

        string[] CheckSearchBarInput(string input);

        FindPeopleInputViewModel InitializeSplitedString(string[] result);

        List<UserInfo> PeopleInfoOutput(FindPeopleInputViewModel findPeopleInput, string userName, string userId);

        List<Post> GetFriendsPosts(string userId);

        Task<Post> CreatePost(string userId, PostViewModel viewModel);

        Task<bool> DeletePost(int postId);

        PostViewModel GetPostToEdit(string userId, int postId);
        Task<Post> EditPost(string userId, PostViewModel postViewModel);

        Task<CommentViewModel> CreateComment(CommentViewModel vm, string userId);
        Task<int> DeleteComment(CommentViewModel vm, string userId);
        Task<string> EditComment(CommentViewModel vm, string userId);

        Task<int> LikePost(int postId, string userId);
        Task<int> UnlikePost(int postId, string userId);

        Task<Bio> CreateBio(string userId, string text);

        Task<UserInfo> EditProfileInfo(string userId, UserInfo userInfo);
    }
}
