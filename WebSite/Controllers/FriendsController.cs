using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSite.AppServices.FriendList;
using WebSite.AppServices.FriendRequestAppService;
using WebSite.AppServices.Profile;
using WebSite.Cores;
using WebSite.Infrastructure;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    [Authorize]
    public class FriendsController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFriendRequest _iFriendRequest;
        private readonly IProfileInfo _iProfile;
        private readonly IFriendList _iFriendList;

        public FriendsController(UserManager<AppUser> userManager, IFriendRequest iFriendRequest,
            IProfileInfo iProfile, IFriendList iFriendList)
        {
            _userManager = userManager;
            _iFriendRequest = iFriendRequest;
            _iProfile = iProfile;
            _iFriendList = iFriendList;
        }

        [HttpGet]
        public IActionResult People(FindPeopleInputViewModel findPeopleInput)
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel output = _iProfile.UserInfoOutput(userId, userName);

            var usersInfoOutput = _iProfile.PeopleInfoOutput(findPeopleInput,userName, userId);
            output.FindPeople = usersInfoOutput;

            return View(output);

        }


        [HttpPost, ActionName("ShowPeople")]
        public IActionResult ShowPeople(string inputToFindPeople)
        {
            string[] result = _iProfile.CheckSearchBarInput(inputToFindPeople);
            FindPeopleInputViewModel findPeopleInput = _iProfile.InitializeSplitedString(result);
            
            return RedirectToAction("People", "Friends", findPeopleInput);
        }

        

        [HttpGet]
        public IActionResult Friends()
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel output = _iProfile.UserInfoOutput(userId, userName);
            var friendsList = _iFriendList.FriendsListOutput(GetUserId());

            output.FriendsList = friendsList;

            return View(output);
        }

        [HttpPost]
        public async Task<IActionResult> SendFriendRequest(string SenderUserName,string ReceiverUserId)
        {
            var senderUser = await _userManager.FindByNameAsync(SenderUserName);
            bool result = await _iFriendRequest.SendFriendRequest(senderUser.Id, ReceiverUserId);

            if (result == true)
            {
                return RedirectToAction("SentFriendRequests","Friends");
            }
            else
            {
                return RedirectToAction("People", "Friends");
            }
            
        }

        [HttpGet]
        public IActionResult SentFriendRequests()
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel output = _iProfile.UserInfoOutput(userId, userName);
            var sentRequests = _iFriendRequest.SentFriendRequestsOutput(GetUserId());

            output.FriendRequests = sentRequests;

            return View(output);
        }

        [HttpGet]
        public IActionResult ReceivedFriendRequests()
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel output = _iProfile.UserInfoOutput(userId, userName);
            var receivedRequests = _iFriendRequest.ReceivedFriendRequestsOutput(GetUserId());

            output.FriendRequests = receivedRequests;

            return View(output);
        }

        

        [HttpPost]
        public async Task<IActionResult> CancelFriendRequest(int id)
        {
            bool result = await _iFriendRequest.CancelFriendRequest(id);

            if (result == true)
            {
                return RedirectToAction("SentFriendRequests", "Friends");
            }
            else
            {
                return RedirectToAction("People", "Friends");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFriend(int id)
        {
            bool result = await _iFriendRequest.RemoveFriend(id);

            if (result == true)
            {
                return RedirectToAction("Friends", "Friends");
            }
            else
            {
                return RedirectToAction("People", "Friends");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AnswerFriendRequest(string Accept, string Decline, int id)
        {
            if(Accept == "Accept")
            {
                bool accept = await _iFriendRequest.AcceptFriendRequest(id);
                if (accept == true)
                {
                    return RedirectToAction("Friends", "Friends");
                }
                
            }
            else if(Decline =="Decline")
            {
                bool decline =await _iFriendRequest.DeclineFriendRequest(id);

                if (decline == true)
                {
                    return RedirectToAction("Friends", "Friends");
                }
                
            }
                return RedirectToAction("ReceivedFriendRequests", "Friends");

            
            
        }
        

    }
}
