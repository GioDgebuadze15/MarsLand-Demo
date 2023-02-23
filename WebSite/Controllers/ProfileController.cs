using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSite.AppServices.Profile;
using WebSite.EntityFramework.DbContext;
using WebSite.Infrastructure;
using WebSite.Models;
using PhotoSauce.MagicScaler;
using WebSite.ViewModels;
using WebSite.AppServices.FriendList;
using WebSite.Cores;
using Microsoft.EntityFrameworkCore;

namespace WebSite.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _regRepository;
        private readonly IProfileInfo _iProfile;
        private readonly IFriendList _iFriendList;
        private readonly IWebHostEnvironment _iWebHostEnvironement;


        public ProfileController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
            AppDbContext regRepository, IProfileInfo iProfile, IWebHostEnvironment iWebHostEnvironement,
            IFriendList iFriendList)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _regRepository = regRepository;
            _iProfile = iProfile;
            _iFriendList = iFriendList;
            _iWebHostEnvironement = iWebHostEnvironement;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel userInfo = _iProfile.ProfileInfoOutput(userId, userName);
            var friendsList = _iFriendList.FriendsListOutput(GetUserId());

            userInfo.FriendsList = friendsList;

            return View(userInfo);
        }




        [HttpGet]
        public IActionResult CreateProfileImage()
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel userInfo = _iProfile.UserInfoOutput(userId, userName);
            return View(userInfo);
        }

        [HttpGet]
        public IActionResult CreateCoverImage()
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel userInfo = _iProfile.UserInfoOutput(userId, userName);
            return View(userInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProfileImage([Bind("ImageId,Title,ImageFile")] ProfileImageModel profileImageModel,
             string identityUserName)
        {
            var user = await _userManager.FindByNameAsync(identityUserName);
            if (ModelState.IsValid)
            {
                string wwwRootPath = _iWebHostEnvironement.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(profileImageModel.ImageFile.FileName);
                string extension = Path.GetExtension(profileImageModel.ImageFile.FileName);
                profileImageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Tools/ProfileImages/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    MagicImageProcessor.ProcessImage(profileImageModel.ImageFile.OpenReadStream(), fileStream, ProfileImageOptions());
                }

                var userInfo = _regRepository.UserAdditionalInfo.FirstOrDefault(x => x.UserId == user.Id);

                var imageModel = new ProfileImageModel
                {
                    UserId = userInfo.UserId,
                    Title = profileImageModel.Title,
                    ImageName = profileImageModel.ImageName
                };


                _regRepository.Add(imageModel);
                await _regRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Profile));
            }

            return View(profileImageModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCoverImage([Bind("ImageId,Title,ImageFile")] CoverImageModel coverImageModel,
             string identityUserName)
        {
            var user = await _userManager.FindByNameAsync(identityUserName);
            if (ModelState.IsValid)
            {
                string wwwRootPath = _iWebHostEnvironement.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(coverImageModel.ImageFile.FileName);
                string extension = Path.GetExtension(coverImageModel.ImageFile.FileName);
                coverImageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Tools/CoverImages/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    MagicImageProcessor.ProcessImage(coverImageModel.ImageFile.OpenReadStream(), fileStream, CoverImageOptions());
                }

                var userInfo = _regRepository.UserAdditionalInfo.FirstOrDefault(x => x.UserId == user.Id);

                var imageModel = new CoverImageModel
                {
                    UserId = userInfo.UserId,
                    Title = coverImageModel.Title,
                    ImageName = coverImageModel.ImageName
                };


                _regRepository.Add(imageModel);
                await _regRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Profile));
            }

            return View(coverImageModel);
        }



        [HttpPost, ActionName("DeleteProfileImage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProfileImage()
        {
            var profileImageModel = _regRepository.ProfileImages.FirstOrDefault(x => x.UserId == GetUserId());

            if (profileImageModel != null)
            {
                string filePath = Path.Combine(_iWebHostEnvironement.WebRootPath, "Tools/ProfileImages", profileImageModel.ImageName);
                FileInfo fileInfo = new FileInfo(filePath);

                if (System.IO.File.Exists(filePath))
                {
                    if (fileInfo != null)
                    {
                        System.IO.File.Delete(filePath);
                        fileInfo.Delete();
                        _regRepository.ProfileImages.Remove(profileImageModel);
                        await _regRepository.SaveChangesAsync();
                    }
                }


            }
            return RedirectToAction(nameof(Profile));
        }

        [HttpPost, ActionName("DeleteCoverImage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCoverImage()
        {
            var coverImageModel = _regRepository.CoverImages.FirstOrDefault(x => x.UserId == GetUserId());

            if (coverImageModel != null)
            {
                string filePath = Path.Combine(_iWebHostEnvironement.WebRootPath, "Tools/CoverImages", coverImageModel.ImageName);
                FileInfo fileInfo = new FileInfo(filePath);

                if (System.IO.File.Exists(filePath))
                {
                    if (fileInfo != null)
                    {
                        System.IO.File.Delete(filePath);
                        fileInfo.Delete();
                        _regRepository.CoverImages.Remove(coverImageModel);
                        await _regRepository.SaveChangesAsync();
                    }
                }


            }
            return RedirectToAction(nameof(Profile));
        }

        [HttpGet]
        public IActionResult EditPost(int PostId)
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel userInfo = _iProfile.UserInfoOutput(userId, userName);
            var post = _iProfile.GetPostToEdit(userId, PostId);

            userInfo.PostViewModel = post;

            return View(userInfo);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(PostViewModel viewModel)
        {
            var userId = GetUserId();
            var post = await _iProfile.EditPost(userId, viewModel);

            return RedirectToAction("Profile", post);

        }


        [HttpPost]
        public async Task<IActionResult> AddBio(string text)
        {
            var bio = await _iProfile.CreateBio(GetUserId(), text);
            return RedirectToAction("Profile", new { bio });
        }

        [HttpGet]
        public IActionResult EditProfileInfo()
        {
            var userName = User.Identity.Name;
            var userId = GetUserId();

            UserInfoCollectionViewModel vm = _iProfile.UserInfoOutput(userId, userName);
            var userInfo = _regRepository.UserAdditionalInfo.FirstOrDefault(x => x.UserId == GetUserId());

            vm.EditProfileInfo = userInfo;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditInfo(UserInfo userInfo)
        {
            var editedUserInfo = await _iProfile.EditProfileInfo(GetUserId(), userInfo);

            return RedirectToAction("Profile", new { editedUserInfo });
        }

        private static ProcessImageSettings ProfileImageOptions() => new ProcessImageSettings
        {
            Width = 960,
            Height = 960,
            ResizeMode = CropScaleMode.Crop


        };

        private static ProcessImageSettings CoverImageOptions() => new ProcessImageSettings
        {
            Width = 960,
            Height = 360,
            ResizeMode = CropScaleMode.Crop,
            SaveFormat = FileFormat.Jpeg,
            JpegQuality = 100,
            JpegSubsampleMode = ChromaSubsampleMode.Subsample420


        };


    }

}
