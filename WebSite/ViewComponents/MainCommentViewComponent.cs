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
    public class MainCommentViewComponent: ViewComponent
    {
        private readonly AppDbContext _regRepository;
        private readonly IProfileInfo _iProfile;


        public MainCommentViewComponent(AppDbContext regRepository, IProfileInfo iProfile)
        {
            _regRepository = regRepository;
            _iProfile = iProfile;
        }

        public async Task<IViewComponentResult> InvokeAsync(UserInfoCollectionViewModel vm, int postId)
        {

            var mainComments = await _regRepository.MainComments
                                                    .Where(x=>x.PostId == postId)
                                                        .Include(x=>x.SubComments)
                                                        .Include(x=>x.User)
                                                            .ThenInclude(x=>x.UserInfo)
                                                                .ThenInclude(x=>x.ProfileImage)
                                                    .ToListAsync();
            var post = await _regRepository.Posts
                                                .FirstOrDefaultAsync(x=>x.PostId == postId);

            vm.CommentViewModel = new CommentViewModel 
            { 
                MainComments = mainComments,
                Post = post,
                PostId = postId
            };

            return View(vm);
        }

    }
}
