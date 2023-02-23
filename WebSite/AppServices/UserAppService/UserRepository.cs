using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSite.Cores;
using WebSite.EntityFramework.DbContext;
using WebSite.ViewModels;

namespace WebSite.AppServices.UserAppService
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _regRepository;

        public UserRepository(AppDbContext regRepository)
        {
            _regRepository = regRepository;
        }

        public UserInfoViewModel GetUserInfo(string userId, string id)
        {
            var vm = new UserInfoViewModel();
            FriendStatus(vm,userId,id);

            var post = _regRepository.Posts
                            .Include(x => x.PostImage)
                            .Include(x => x.PostLikes)
                            .Include(x => x.MainComments)
                                .ThenInclude(x => x.SubComments)
                             .ToList();

            var userInfo = _regRepository.UserAdditionalInfo
                                            .Include(x => x.User)
                                                .ThenInclude(x => x.Posts)
                                                .Include(x => x.ProfileImage)
                                            .Include(x => x.CoverImage)
                                                .Include(x => x.Bio)
                                            .FirstOrDefault(x => x.UserId == id);
            if (userInfo == null)
            {
                return new UserInfoViewModel();
            }
            vm.UserInfo = userInfo;
            return vm;
        }


        public List<UserInfo> GetAllUserInfo()
        {
            var allUserInfo = _regRepository.UserAdditionalInfo
                                            .Include(x => x.User)
                                                .Include(x => x.ProfileImage)
                                            .ToList();
            if (allUserInfo.Count == 0)
            {
                return new List<UserInfo>();
            }
            return allUserInfo;
        }

        private void FriendStatus(UserInfoViewModel vm, string userId, string id)
        {
            var request = _regRepository.FriendRequests
                                    .Where(x => x.FriendUsers
                                            .Any(y => y.UserId == userId) && x.FriendUsers
                                            .Any(y => y.UserId == id))
                                    .Include(x=>x.FriendUsers)
                                    .FirstOrDefault();
            if(request != null)
            {
                vm.FriendStatus = request.FriendStatus;
                var role = request.FriendUsers.Where(x => x.UserId != userId).FirstOrDefault();
                vm.Role = role.Role;
                vm.FriendRequestId = request.Id;
            }
            else
            {
                vm.FriendStatus = null;
                vm.Role = null;
                vm.FriendRequestId = null;
            }
        }
    }
}
