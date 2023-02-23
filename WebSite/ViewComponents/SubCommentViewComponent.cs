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
    public class SubCommentViewComponent: ViewComponent
    {
        private readonly AppDbContext _regRepository;
        private readonly IProfileInfo _iProfile;


        public SubCommentViewComponent(AppDbContext regRepository, IProfileInfo iProfile)
        {
            _regRepository = regRepository;
            _iProfile = iProfile;
        }

        public async Task<IViewComponentResult> InvokeAsync(UserInfoCollectionViewModel vm, int mainCommentId)
        {

            var subComments = await _regRepository.SubComments
                                                    .Where(x => x.MainCommentId == mainCommentId)
                                                    .Include(x => x.User)
                                                        .ThenInclude(x => x.UserInfo)
                                                            .ThenInclude(x => x.ProfileImage)
                                                    .ToListAsync();
            var post = await _regRepository.MainComments
                                            .Where(x => x.Id == mainCommentId)
                                                .Include(x => x.Post)
                                            .Select(x => x.Post)
                                                .FirstOrDefaultAsync();
            vm.CommentViewModel = new CommentViewModel
            {
                SubComments = subComments,
                MainCommentId = mainCommentId,
                Post = post,
                PostId = post.PostId
            };

            return View(vm);
        }
    }
}
