using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Cores;
using WebSite.ViewModels;

namespace WebSite.AppServices.UserAppService
{
    public interface IUserRepository
    {
        UserInfoViewModel GetUserInfo(string userId,string id);

        List<UserInfo> GetAllUserInfo();
    }
}
