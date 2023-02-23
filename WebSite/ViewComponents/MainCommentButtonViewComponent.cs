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
    public class MainCommentButtonViewComponent: ViewComponent
    {
        private readonly AppDbContext _regRepository;
        private readonly IProfileInfo _iProfile;


        public MainCommentButtonViewComponent(AppDbContext regRepository, IProfileInfo iProfile)
        {
            _regRepository = regRepository;
            _iProfile = iProfile;
        }

        public async Task<IViewComponentResult> InvokeAsync(UserInfoCollectionViewModel vm, int mainCommentId)
        {

            var mainComment = await _regRepository.MainComments
                                                .FirstOrDefaultAsync(x => x.Id == mainCommentId);
            var post = await _regRepository.MainComments
                                            .Include(x => x.Post)
                                                .ThenInclude(x => x.User)
                                                .Where(x => x.Id == mainCommentId)
                                            .Select(x => x.Post)
                                                .FirstOrDefaultAsync();

            vm.CommentViewModel = new CommentViewModel
            {
                MainComment = mainComment,
                Post = post,
                PostId = post.PostId
            };

            return View(vm);
        }

       
    }
}
