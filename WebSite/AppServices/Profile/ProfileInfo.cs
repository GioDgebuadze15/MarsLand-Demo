using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhotoSauce.MagicScaler;
using WebSite.Cores;
using WebSite.EntityFramework.DbContext;
using WebSite.Enums;
using WebSite.Models;
using WebSite.Models.Comments;
using WebSite.ViewModels;

namespace WebSite.AppServices.Profile
{
    public class ProfileInfo : IProfileInfo
    {
        private readonly AppDbContext _regRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _iWebHostEnvironement;

        public ProfileInfo(AppDbContext regRepository, UserManager<AppUser> userManager,
            IWebHostEnvironment iWebHostEnvironement)
        {
            _regRepository = regRepository;
            _userManager = userManager;
            _iWebHostEnvironement = iWebHostEnvironement;
        }


        public UserInfoCollectionViewModel ProfileInfoOutput(string id, string username)
        {
            var post = _regRepository.Posts
                            .Include(x => x.PostImage)
                            .Include(x => x.PostLikes)
                            .Include(x => x.MainComments)
                                .ThenInclude(x => x.SubComments)
                             .ToList();

            var identityUser = _userManager.FindByNameAsync(username).Result;

            var userInfo = _regRepository.UserAdditionalInfo
                            .Include(x => x.ProfileImage)
                                .Include(x => x.CoverImage)
                                 .Include(x => x.Bio)
                            .Include(x => x.User)
                                .ThenInclude(x => x.Posts)
                            .FirstOrDefault(x => x.UserId == id);

            var userInfoCollection = new UserInfoCollectionViewModel
            {
                AppUser = identityUser

            };

            return userInfoCollection;
        }

        public UserInfoCollectionViewModel UserInfoOutput(string id, string username)
        {

            var identityUser = _userManager.FindByNameAsync(username).Result;

            var userInfo = _regRepository.UserAdditionalInfo
                            .Include(x => x.ProfileImage)
                            .Include(x => x.User)
                                .FirstOrDefault(x => x.UserId == id);

            var userInfoCollection = new UserInfoCollectionViewModel
            {
                AppUser = identityUser

            };

            return userInfoCollection;
        }

        public string[] CheckSearchBarInput(string input)
        {
            string[] FullName = new string[2];
            if (input != "")
            {
                bool result = input.Contains(" ");
                if (result == true)
                {


                    string[] word = input.Split(" ");
                    for (int i = 0; i < 2; i++)
                    {
                        FullName[i] = word[i];
                    }

                    return (FullName);
                }
                else
                {
                    FullName[0] = input;
                    return FullName;
                }
            }
            return (FullName);

        }

        public FindPeopleInputViewModel InitializeSplitedString(string[] result)
        {
            FindPeopleInputViewModel findPeopleInput = new FindPeopleInputViewModel();

            if (result[1] == null)
            {
                findPeopleInput.Username = result[0];
            }
            else
            {
                findPeopleInput.FirstName = result[0];
                findPeopleInput.LastName = result[1];
            }
            return findPeopleInput;
        }

        public List<UserInfo> PeopleInfoOutput(FindPeopleInputViewModel findPeopleInput, string userName, string userId)
        {
            var result = new List<UserInfo>();
            if (findPeopleInput.Username == userName)
            {
                return result;
            }
            else if (findPeopleInput.Username == null)
            {
                var users = _regRepository.UserAdditionalInfo
                                            .Where(x => x.FirstName == findPeopleInput.FirstName && x.LastName == findPeopleInput.LastName &&
                                        (x.User.UserName != userName))
                                        .Include(x => x.User)
                                        .ThenInclude(x => x.FriendShips.Where(x => x.FriendRequest.FriendUsers.Any(y => y.UserId == userId)))
                                            .ThenInclude(x => x.FriendRequest)
                                        .Include(x => x.ProfileImage)
                                        .ToList();
                if (users.Count != 0)
                {
                    result = users;
                }
            }
            else
            {
                if (!(findPeopleInput.Username.ToLower() == userName.ToLower()))
                {
                    var user = _regRepository.UserAdditionalInfo
                                                    .Where(x => x.User.UserName == findPeopleInput.Username)
                                            .Include(x => x.User)
                                            .ThenInclude(x => x.FriendShips.Where(x => x.FriendRequest.FriendUsers.Any(y => y.UserId == userId)))
                                                .ThenInclude(x => x.FriendRequest)
                                            .Include(x => x.ProfileImage)
                                            .FirstOrDefault();
                    if (user != null)
                    {
                        result.Add(user);
                    }
                }
            }
            return result;
        }


        public List<Post> GetFriendsPosts(string userId)
        {
            var allposts = _regRepository.Posts
                                            .Include(x => x.PostImage)
                                            .Include(x => x.PostLikes)
                                            .Select(x => new 
                                            {
                                                x.PostId,
                                                x.PostImage,
                                                x.Text,
                                                x.Privacy,
                                                x.Created,
                                                x.Edited,
                                                x.User,
                                                x.PostLikes,
                                                //change this
                                                
                                                
                                            })
                                            .ToList();

            var friends = _regRepository.FriendRequests
                                    .Where(x => x.FriendStatus == FriendRequestEnum.Approved && x.FriendUsers
                                                                                            .Any(y => y.UserId == userId))
                                    .Include(x => x.FriendUsers)
                                        .ThenInclude(x => x.User)
                                        .ThenInclude(x => x.UserInfo)
                                                .ThenInclude(x => x.ProfileImage)
                                    .SelectMany(x => x.FriendUsers.Where(y => y.UserId != userId))
                                        .ToList();

            var friendsPosts = friends.SelectMany(x => x.User.Posts);

            if (!friendsPosts.Any())
            {
                return new List<Post>();
            }

            var result = new List<Post>(friendsPosts);

            return result;
        }


        public async Task<Post> CreatePost(string userId, PostViewModel viewModel)
        {
            var post = new Post
            {
                UserId = userId,
                Text = viewModel.Text,
                Created = DateTime.Now,
                Privacy = viewModel.Privacy
            };

            if (viewModel.ImageFile != null)
            {
                viewModel.ImageName = CreatePostImage(viewModel);
            }

            if (!string.IsNullOrEmpty(viewModel.ImageName))
            {
                post.PostImage = new PostImageModel
                {
                    ImageName = viewModel.ImageName
                };
            }

            _regRepository.Add(post);
            await _regRepository.SaveChangesAsync();

            return post;
        }


        public async Task<bool> DeletePost(int postId)
        {
            var post = _regRepository.Posts
                                   .Include(x => x.PostImage)
                                   .FirstOrDefault(x => x.PostId == postId);

            if (post.PostImage != null)
            {
                if (DeletePostImageFromFolder(post.PostImage.ImageName))
                {
                    _regRepository.Posts.Remove(post);
                    await _regRepository.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            else
            {
                _regRepository.Posts.Remove(post);
                await _regRepository.SaveChangesAsync();

                return true;
            }
        }



        public PostViewModel GetPostToEdit(string userId, int postId)
        {
            var post = _regRepository.Posts
                                .Include(x => x.PostImage)
                                .FirstOrDefault(x => x.PostId == postId);

            if (userId == post.UserId)
            {
                var postViewModel = new PostViewModel
                {
                    PostId = post.PostId,
                    Text = post.Text,
                    Privacy = post.Privacy
                };
                if (post.PostImage != null)
                {
                    postViewModel.ImageName = post.PostImage.ImageName;
                }
                return postViewModel;
            }
            return new PostViewModel();
        }


        public async Task<Post> EditPost(string userId, PostViewModel postViewModel)
        {
            var post = _regRepository.Posts
                            .Include(x => x.PostImage)
                            .FirstOrDefault(x => x.PostId == postViewModel.PostId);

            if (userId == post.UserId)
            {
                post.Text = postViewModel.Text;
                post.Privacy = postViewModel.Privacy;
                post.Edited = DateTime.Now;

                if (post.PostImage != null)
                {
                    if (postViewModel.ImageFile != null)
                    {
                        if (DeletePostImageFromFolder(post.PostImage.ImageName))
                        {
                            var newImageName = CreatePostImage(postViewModel);
                            post.PostImage.ImageName = newImageName;


                        }
                    }

                    _regRepository.Entry(post).State = EntityState.Modified;
                    await _regRepository.SaveChangesAsync();

                    return post;
                }
                else
                {
                    if (postViewModel.ImageFile != null)
                    {

                        var imageName = CreatePostImage(postViewModel);
                        var PostImage = new PostImageModel
                        {
                            PostId = post.PostId,
                            ImageName = imageName
                        };

                        _regRepository.Add(PostImage);
                        await _regRepository.SaveChangesAsync();

                        return post;


                    }
                    _regRepository.Entry(post).State = EntityState.Modified;
                    await _regRepository.SaveChangesAsync();

                    return post;
                }


            }
            return new Post();

        }

        public async Task<CommentViewModel> CreateComment(CommentViewModel vm, string userId)
        {
            var post = _regRepository.Posts
                                    .Include(x => x.MainComments)
                                        .ThenInclude(x => x.SubComments)
                                    .FirstOrDefault(x => x.PostId == vm.PostId);

            if (post != null)
            {
                if (vm.MainCommentId == 0)
                {
                    int mainComId = await LeaveMainComment(vm, post, userId);
                    vm.MainCommentId = mainComId;

                    int NumOfComs = CountNumberOfComs(post);
                    vm.NumOfComments = NumOfComs;

                    return vm;
                }
                else
                {
                    int subComId = await LeaveSubComment(vm, userId);
                    vm.SubCommentId = subComId;

                    int NumOfComs = CountNumberOfComs(post);
                    vm.NumOfComments = NumOfComs;

                    return vm;
                }
            }
            else
            {
                return new CommentViewModel();
            }
        }

        public async Task<int> DeleteComment(CommentViewModel vm, string userId)
        {
            var post = _regRepository.Posts
                                    .Include(x => x.MainComments)
                                        .ThenInclude(x => x.SubComments)
                                    .FirstOrDefault(x => x.PostId == vm.PostId);
            int result = 0;



            if (post != null)
            {
                int NumOfComs = CountNumberOfComs(post);

                if (vm.MainCommentId != 0 && vm.SubCommentId == null)
                {
                    result = await DeleteMainComment(vm, userId);
                    if (result > 0)
                    {
                        return (NumOfComs - result);
                    }

                }
                else
                {
                    await DeleteSubComment(vm, userId);
                    return (NumOfComs - 1);
                }
            }
            return result;
        }



        public async Task<string> EditComment(CommentViewModel vm, string userId)
        {
            var post = _regRepository.Posts
                                    .Include(x => x.MainComments)
                                        .ThenInclude(x => x.SubComments)
                                    .FirstOrDefault(x => x.PostId == vm.PostId);
            string result;
            if (post != null)
            {
                if (vm.MainCommentId != 0 && vm.SubCommentId == null)
                {
                    await EditMainComment(vm, userId);
                    result = "Ok";
                    return result;
                }
                else
                {
                    await EditSubComment(vm, userId);
                    result = "Ok";
                    return result;
                }
            }
            else
            {
                result = "Error";
                return result;
            }
        }



        public async Task<int> LikePost(int postId, string userId)
        {
            var post = _regRepository.Posts
                                    .Include(x => x.PostLikes)
                                    .FirstOrDefault(x => x.PostId == postId);
            var result = -1;
            if (post != null)
            {
                if (!IsAlreadyLiked(post, userId))
                {
                    post.PostLikes ??= new List<PostLike>();

                    post.PostLikes.Add(new PostLike
                    {
                        LikerId = userId,
                        Create = DateTime.Now
                    });

                    _regRepository.Posts.Update(post);
                    await _regRepository.SaveChangesAsync();

                    result = post.PostLikes.Count;
                    return result;
                }
                return result;
            }
            return result;
        }

        public async Task<int> UnlikePost(int postId, string userId)
        {
            var post = _regRepository.Posts
                                    .Include(x => x.PostLikes)
                                    .FirstOrDefault(x => x.PostId == postId);

            var result = -1;
            if (post != null)
            {
                if (IsAlreadyLiked(post, userId))
                {
                    var postLike = post.PostLikes.FirstOrDefault(x => x.LikerId == userId);


                    _regRepository.PostLikes.Remove(postLike);

                    result = post.PostLikes.Count - 1;

                    await _regRepository.SaveChangesAsync();

                    return result;
                }
                return result;

            }
            return result;
        }

        private static int CountNumberOfComs(Post post)
        {
            int NumOfMainComs = post.MainComments.Count;
            int NumOfSubComs = 0;

            foreach (var sc in post.MainComments)
            {
                if (sc.SubComments != null)
                {
                    NumOfMainComs += sc.SubComments.Count;
                }
            }
            int NumOfSumComs = NumOfMainComs + NumOfSubComs;
            return NumOfSumComs;
        }

        private async Task EditMainComment(CommentViewModel vm, string userId)
        {
            var mainCom = _regRepository.MainComments
                                            .Where(x => x.Id == vm.MainCommentId)
                                                .FirstOrDefault(x => x.UserId == userId);
            if (mainCom != null)
            {
                mainCom.Text = vm.CommentText;
                mainCom.Edited = DateTime.Now;

                _regRepository.Entry(mainCom).State = EntityState.Modified;
                await _regRepository.SaveChangesAsync();
            }
        }

        private async Task EditSubComment(CommentViewModel vm, string userId)
        {
            var subCom = _regRepository.SubComments
                                            .Where(x => x.Id == vm.SubCommentId)
                                                .FirstOrDefault(x => x.UserId == userId);
            if (subCom != null)
            {
                subCom.Text = vm.CommentText;
                subCom.Edited = DateTime.Now;

                _regRepository.Entry(subCom).State = EntityState.Modified;
                await _regRepository.SaveChangesAsync();
            }
        }

        private async Task<int> DeleteMainComment(CommentViewModel vm, string userId)
        {
            var mainCom = _regRepository.MainComments
                                            .Include(x => x.SubComments)
                                            .Where(x => x.Id == vm.MainCommentId)
                                                .FirstOrDefault(x => x.UserId == userId);

            int result = 0;
            if (mainCom != null)
            {
                _regRepository.Remove(mainCom);
                await _regRepository.SaveChangesAsync();

                result = (mainCom.SubComments.Count + 1);
            }
            return result;
        }

        private async Task DeleteSubComment(CommentViewModel vm, string userId)
        {
            var subCom = _regRepository.SubComments
                                            .Where(x => x.Id == vm.SubCommentId)
                                                .FirstOrDefault(x => x.UserId == userId);
            if (subCom != null)
            {
                _regRepository.Remove(subCom);
                await _regRepository.SaveChangesAsync();
            }
        }

        private static bool IsAlreadyLiked(Post post, string userId)
        {
            if (post.PostLikes.Any(x => x.LikerId == userId))
            {
                return true;
            }
            return false;
        }

        private async Task<int> LeaveMainComment(CommentViewModel vm, Post post, string userId)
        {
            post.MainComments ??= new List<MainComment>();

            post.MainComments.Add(new MainComment
            {
                Text = vm.CommentText,
                Created = DateTime.Now,
                UserId = userId
            });

            _regRepository.Posts.Update(post);
            await _regRepository.SaveChangesAsync();

            return post.MainComments.Select(x => x.Id).LastOrDefault();
        }

        private async Task<int> LeaveSubComment(CommentViewModel vm, string userId)
        {
            var comment = new SubComment
            {
                MainCommentId = (int)vm.MainCommentId,
                Text = vm.CommentText,
                Created = DateTime.Now,
                UserId = userId
            };
            _regRepository.SubComments.Add(comment);
            await _regRepository.SaveChangesAsync();

            return comment.Id;
        }

        public async Task<Bio> CreateBio(string userId, string text)
        {
            var checkBio = _regRepository.Bios.FirstOrDefault(x => x.UserId == userId);


            if (checkBio != null)
            {
                checkBio.Text = text;

                _regRepository.Entry(checkBio).State = EntityState.Modified;
                await _regRepository.SaveChangesAsync();

                return checkBio;
            }
            else
            {

                var bio = new Bio
                {
                    UserId = userId,
                    Text = text
                };


                _regRepository.Add(bio);
                await _regRepository.SaveChangesAsync();

                return bio;
            }
        }


        public async Task<UserInfo> EditProfileInfo(string userId, UserInfo userInfo)
        {
            var userInfoCore = _regRepository.UserAdditionalInfo.FirstOrDefault(x => x.UserId == userId);

            userInfoCore.DateOfBirth = userInfo.DateOfBirth;
            userInfoCore.Gender = userInfo.Gender;
            userInfoCore.Country = userInfo.Country;

            _regRepository.Entry(userInfoCore).State = EntityState.Modified;
            await _regRepository.SaveChangesAsync();

            return userInfoCore;
        }


        private string CreatePostImage(PostViewModel postViewModel)
        {

            string wwwRootPath = _iWebHostEnvironement.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(postViewModel.ImageFile.FileName);
            string extension = Path.GetExtension(postViewModel.ImageFile.FileName);
            string imageName = postViewModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Tools/PostImages/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                MagicImageProcessor.ProcessImage(postViewModel.ImageFile.OpenReadStream(), fileStream, PostImageOptions());
            }


            return imageName;
        }


        private bool DeletePostImageFromFolder(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                string filePath = Path.Combine(_iWebHostEnvironement.WebRootPath, "Tools/PostImages", Id);
                FileInfo fileInfo = new FileInfo(filePath);

                if (File.Exists(filePath))
                {
                    if (fileInfo != null)
                    {
                        File.Delete(filePath);
                        fileInfo.Delete();
                        return true;
                    }
                }
            }
            return false;
        }

        private static ProcessImageSettings PostImageOptions() => new ProcessImageSettings
        {
            Width = 960,
            Height = 960,
            ResizeMode = CropScaleMode.Crop,
            SaveFormat = FileFormat.Jpeg,
            JpegQuality = 100,
            JpegSubsampleMode = ChromaSubsampleMode.Subsample420


        };


    }
}
