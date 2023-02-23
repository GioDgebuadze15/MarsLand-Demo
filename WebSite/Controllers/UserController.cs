using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSite.AppServices.Profile;
using WebSite.AppServices.UserAppService;
using WebSite.Cores;
using WebSite.EntityFramework.DbContext;
using WebSite.Infrastructure;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IProfileInfo _iProfile;
        private readonly IUserRepository _iUser;

        public UserController(IProfileInfo iProfile, IUserRepository iUser)
        {
            _iProfile = iProfile;
            _iUser = iUser;
        }


        [HttpGet]
        public IActionResult UserProfileView(string Id)
        {
            var userId = GetUserId();

            if (Id == userId)
            {
                return RedirectToAction("Profile", "Profile");
            }
            else
            {
                var userName = User.Identity.Name;

                UserInfoCollectionViewModel output = _iProfile.UserInfoOutput(userId, userName);
                var userInfo = _iUser.GetUserInfo(userId, Id);

                output.UserInfoView = userInfo;
                return View(output);
            }
        }


        [HttpGet]
        public IActionResult AllUsers()
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel output = _iProfile.UserInfoOutput(userId, userName);
            var allUserInfo = _iUser.GetAllUserInfo();

            output.AllUserInfoView = allUserInfo;
            return View(output);
        }
    }
}
