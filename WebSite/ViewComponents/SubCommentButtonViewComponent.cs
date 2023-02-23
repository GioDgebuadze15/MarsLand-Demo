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
    public class SubCommentButtonViewComponent : ViewComponent
    {
        private readonly AppDbContext _regRepository;
        private readonly IProfileInfo _iProfile;


        public SubCommentButtonViewComponent(AppDbContext regRepository, IProfileInfo iProfile)
        {
            _regRepository = regRepository;
            _iProfile = iProfile;
        }

        public async Task<IViewComponentResult> InvokeAsync(UserInfoCollectionViewModel vm, int subCommentId)
        {

            var subComment = await _regRepository.SubComments
                                                    .FirstOrDefaultAsync(x => x.Id == subCommentId);
            var mainCommentId = await _regRepository.SubComments
                                                    .Where(x => x.Id == subCommentId)
                                                    .Select(x => x.MainCommentId)
                                                        .FirstOrDefaultAsync();
            var post = await _regRepository.MainComments
                                            .Include(x => x.Post)
                                                .Where(x => x.Id == mainCommentId)
                                            .Select(x => x.Post)
                                                .FirstOrDefaultAsync();

            vm.CommentViewModel = new CommentViewModel
            {
                SubComment = subComment,
                Post = post,
                PostId = post.PostId
            };

            return View(vm);
        }
    }
}
