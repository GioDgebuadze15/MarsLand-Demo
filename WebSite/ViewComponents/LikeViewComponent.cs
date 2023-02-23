using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.AppServices.Profile;
using WebSite.EntityFramework.DbContext;
using WebSite.ViewModels;

namespace WebSite.ViewComponents
{
    public class LikeViewComponent: ViewComponent
    {
        private readonly AppDbContext _regRepository;
        private readonly IProfileInfo _iProfile;


        public LikeViewComponent(AppDbContext regRepository, IProfileInfo iProfile)
        {
            _regRepository = regRepository;
            _iProfile = iProfile;
        }

        public async Task<IViewComponentResult> InvokeAsync(UserInfoCollectionViewModel vm, int postId)
        {

            var likerUser = await _regRepository.PostLikes
                                                   .FirstOrDefaultAsync(x=>x.PostId == postId
                                                            && x.LikerId == vm.AppUser.Id);
            var post = await _regRepository.Posts
                                                .FirstOrDefaultAsync(x => x.PostId == postId);
            if (likerUser != null)
            {
                vm.CommentViewModel = new CommentViewModel
                {
                    HasAlreadyLiked = true,
                    Post = post,
                    PostId = postId
                };
            }
            else
            {
                vm.CommentViewModel = new CommentViewModel
                {
                    HasAlreadyLiked = false,
                    Post = post,
                    PostId = postId
                };

            }

            return View(vm);
        }
    }
}
