using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebSite.AppServices.Profile;
using WebSite.EntityFramework.DbContext;
using WebSite.Hubs;
using WebSite.Infrastructure;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    [Authorize]
    public class ForumController : BaseController
    {
        private readonly AppDbContext _regRepository;
        private readonly IProfileInfo _iProfile;
        private readonly IHubContext<PostHub> _postHub;

        public ForumController(AppDbContext regRepository, IProfileInfo iProfile,
            IHubContext<PostHub> postHub)
        {
            _regRepository = regRepository;
            _iProfile = iProfile;
            _postHub = postHub;
        }

        [HttpGet]
        public IActionResult Forum()
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel userInfo = _iProfile.UserInfoOutput(userId, userName);
            var friendPosts = _iProfile.GetFriendsPosts(GetUserId());

            userInfo.FriendsPosts = friendPosts;

            return View(userInfo);



        }

        public IActionResult GetMainCommentComponent(int PostId)
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel userInfo = _iProfile.UserInfoOutput(userId, userName);
            return ViewComponent("MainComment", new{ postId = PostId, vm = userInfo });
        }
        public IActionResult GetSubCommentComponent(int MainCommentId)
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel userInfo = _iProfile.UserInfoOutput(userId, userName);
            return ViewComponent("SubComment", new { mainCommentId = MainCommentId, vm = userInfo });
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel viewModel)
        {
            var userId = GetUserId();
            var post = await _iProfile.CreatePost(userId, viewModel);

            return RedirectToAction("Forum", post);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int PostId)
        {
            await _iProfile.DeletePost(PostId);
            return RedirectToAction("Profile", "Profile");

        }

        

        [HttpPost]
        public async Task<IActionResult> CommentOnPost(CommentViewModel vm)
        {
            if (!ModelState.IsValid)
                return Json("");

            if (vm.MainCommentId == null)
            {
                vm.MainCommentId = 0;
            }
            var viewModel = await _iProfile.CreateComment(vm, GetUserId());

            if (viewModel == null)
            {
                return Json("");
            }
            else
            {
                var userName = User.Identity.Name;
                var userId = GetUserId();

                UserInfoCollectionViewModel userInfo = _iProfile.UserInfoOutput(userId, userName);

                if (viewModel.SubCommentId != null && viewModel.MainCommentId != null)
                {

                    if (userInfo.AppUser.UserInfo.ProfileImage != null)
                    {
                        await _postHub.Clients.Groups(vm.PostId.ToString())
                        .SendAsync("ReceiveSubComment", new
                        {
                            UserId = userInfo.AppUser.Id,
                            UserName = userInfo.AppUser.UserName,
                            FirstName = userInfo.AppUser.UserInfo.FirstName,
                            LastName = userInfo.AppUser.UserInfo.LastName,
                            ProfileImageName = userInfo.AppUser.UserInfo.ProfileImage.ImageName,
                            Gender = userInfo.AppUser.UserInfo.Gender,

                            PostId = vm.PostId,
                            Text = vm.CommentText,
                            NumOfComments = vm.NumOfComments,
                            MainCommentId = vm.MainCommentId,
                            SubCommentId = vm.SubCommentId
                        });
                    }
                    else
                    {
                        await _postHub.Clients.Groups(vm.PostId.ToString())
                        .SendAsync("ReceiveSubComment", new
                        {
                            UserId = userInfo.AppUser.Id,
                            UserName = userInfo.AppUser.UserName,
                            FirstName = userInfo.AppUser.UserInfo.FirstName,
                            LastName = userInfo.AppUser.UserInfo.LastName,
                            Gender = userInfo.AppUser.UserInfo.Gender,


                            PostId = vm.PostId,
                            Text = vm.CommentText,
                            NumOfComments = vm.NumOfComments,
                            MainCommentId = vm.MainCommentId,
                            SubCommentId = vm.SubCommentId
                        });
                    }
                    return ViewComponent("SubCommentButton", new { vm=vm,subCommentId = vm.SubCommentId });
                }
                else
                {
                    if (userInfo.AppUser.UserInfo.ProfileImage != null)
                    {
                        await _postHub.Clients.Groups(vm.PostId.ToString())
                        .SendAsync("ReceiveComment", new
                        {
                            UserId = userInfo.AppUser.Id,
                            UserName = userInfo.AppUser.UserName,
                            FirstName = userInfo.AppUser.UserInfo.FirstName,
                            LastName = userInfo.AppUser.UserInfo.LastName,
                            ProfileImageName = userInfo.AppUser.UserInfo.ProfileImage.ImageName,
                            Gender = userInfo.AppUser.UserInfo.Gender,


                            PostId = vm.PostId,
                            Text = vm.CommentText,
                            NumOfComments = vm.NumOfComments,
                            MainCommentId = vm.MainCommentId
                        });

                        
                    }
                    else
                    {
                        await _postHub.Clients.Groups(vm.PostId.ToString())
                        .SendAsync("ReceiveComment", new
                        {
                            UserId = userInfo.AppUser.Id,
                            UserName = userInfo.AppUser.UserName,
                            FirstName = userInfo.AppUser.UserInfo.FirstName,
                            LastName = userInfo.AppUser.UserInfo.LastName,
                            Gender = userInfo.AppUser.UserInfo.Gender,


                            PostId = vm.PostId,
                            Text = vm.CommentText,
                            NumOfComments = vm.NumOfComments,
                            MainCommentId = vm.MainCommentId
                        });

                    }
                   
                    return ViewComponent("MainCommentButton", new {vm=vm, mainCommentId = vm.MainCommentId });
                }

            }

        }

        [HttpPost]
        public async Task<JsonResult> DeletePostComment(CommentViewModel vm)
        {
            var result = await _iProfile.DeleteComment(vm, GetUserId());
            if (result == 0)
            {
                return Json("");
            }
            else
            {
                vm.NumOfComments = result;

                if (vm.SubCommentId != null && vm.MainCommentId != null)
                {
                    await _postHub.Clients.Groups(vm.PostId.ToString())
                            .SendAsync("DeleteSubComment", new
                            {
                                SubCommentId = vm.SubCommentId,
                                NumOfComments = vm.NumOfComments
                            });
                }
                else
                {
                    await _postHub.Clients.Groups(vm.PostId.ToString())
                            .SendAsync("DeleteComment", new
                            {
                                MainCommentId = vm.MainCommentId,
                                NumOfComments = vm.NumOfComments
                            });
                }
                return Json(vm);
            }
        }

        [HttpPost]
        public async Task<JsonResult> EditPostComment(CommentViewModel vm)
        {
            var result = await _iProfile.EditComment(vm, GetUserId());
            if (result == "Ok")
            {
                if (vm.SubCommentId != null && vm.MainCommentId != null)
                {
                    await _postHub.Clients.Groups(vm.PostId.ToString())
                            .SendAsync("EditSubComment", new
                            {
                                Text = vm.CommentText,
                                SubCommentId = vm.SubCommentId
                            });
                }
                else
                {
                    await _postHub.Clients.Groups(vm.PostId.ToString())
                            .SendAsync("EditComment", new
                            {
                                Text = vm.CommentText,
                                MainCommentId = vm.MainCommentId

                            });
                }
                return Json(vm);
            }
            else
            {
                return Json("");
            }
        }

        [HttpPost]
        public async Task<IActionResult> LikePost(CommentViewModel vm)
        {
            int result = await _iProfile.LikePost(vm.PostId, GetUserId());

            if (result == -1)
            {
                return Json("");
            }
            else
            {
                vm.NumOfLikes = result;

                await _postHub.Clients.Groups(vm.PostId.ToString())
                .SendAsync("ReceiveLike", new
                {
                    PostId = vm.PostId,
                    NumOfLikes = result
                });

            }
            return ViewComponent("Like", new { postId = vm.PostId });
        }

        [HttpPost]
        public async Task<IActionResult> UnlikePost(CommentViewModel vm)
        {
            int result = await _iProfile.UnlikePost(vm.PostId, GetUserId());

            if (result == -1)
            {
                return Json("");
            }
            else
            {
                vm.NumOfLikes = result;

                await _postHub.Clients.Groups(vm.PostId.ToString())
                .SendAsync("ReceiveLike", new
                {
                    PostId = vm.PostId,
                    NumOfLikes = result
                });

            }
            return ViewComponent("Like", new { postId = vm.PostId });
        }
    }
}
