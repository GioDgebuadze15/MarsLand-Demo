using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSite.AppServices.LogIn;
using WebSite.AppServices.MailVerification;
using WebSite.Cores;
using WebSite.EntityFramework.DbContext;
using WebSite.Enums;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogIn _iLogIn;
        private readonly AppDbContext _regRepository;
        private readonly IMailVerification _iMailVerification;

        public LoginController(SignInManager<AppUser> signInManager, ILogIn iLogIn, AppDbContext regRepository,
            UserManager<AppUser> userManager, IMailVerification iMailVerification)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _iLogIn = iLogIn;
            _regRepository = regRepository;
            _iMailVerification = iMailVerification;
        }



        [HttpPost]
        public async Task<JsonResult> LogIn(string UsernameOrEmail, string logPassword)
        {
            string result = await _iLogIn.LogIn(UsernameOrEmail, logPassword);
            if (result == "Successful")
            {
                return Json(new { redirectUrl = Url.Action("Profile", "Profile"), isRedirect = true });
            }
            else if (result == "ConfirmEmail")
            {
                if (_iLogIn.IsValidEmail(UsernameOrEmail))
                {
                    var model = _iMailVerification.GenerateEmailConfirmationCode(UsernameOrEmail);
                    return Json(new { redirectUrl = Url.Action("VerificationPage", "LogIn", model), isRedirect = true });
                }
                else
                {
                    string email = _iLogIn.GetUserEmail(UsernameOrEmail);
                    if (email != "")
                    {
                        var model = _iMailVerification.GenerateEmailConfirmationCode(email);
                        return Json(new { redirectUrl = Url.Action("VerificationPage", "LogIn", model), isRedirect = true });
                    }
                    else
                    {
                        return Json("");
                    }
                }

            }
            else
            {
                return Json(result);
            }
        }



        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult VerificationPage(MailVerificationModel model)
        {
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmailVerification(MailVerificationModel mailVerificationModel)
        {
            string result = await _iMailVerification.CheckVerificationPurpose(mailVerificationModel);

            if (result == "Verified")
            {
                return RedirectToAction("Profile", "Profile");
            }
            else if (result == "RecoverPassword")
            {
                return RedirectToAction("ForgotPassword", mailVerificationModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public IActionResult ForgotPassword(MailVerificationModel mailVerificationModel)
        {
            return View(mailVerificationModel);
        }

        [HttpPost]
        public async Task<JsonResult> ForgotPassword(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user != null)
            {
                var model = _iMailVerification.GenerateEmailConfirmationCode(Email);
                model.Puropse = MailVerificationPurposeEnum.RecoverPassword;

                return Json(new { redirectUrl = Url.Action("VerificationPage", "LogIn", model), isRedirect = true });


            }
            else
            {
                return Json("UserError");
            }
        }

        [HttpPost]
        public async Task<JsonResult> RecoverPassword(string Email, string newPassword, string confirmPassword)
        {

            if ((Email != "" && newPassword != "" && confirmPassword != "") && newPassword == confirmPassword)
            {
                if (ModelState.IsValid)
                {
                    var result = await _iLogIn.ResetPassword(Email, newPassword);
                    if (result.Succeeded)
                    {
                        return Json(new { redirectUrl = Url.Action("Profile", "Profile"), isRedirect = true });
                    }
                    else
                    {
                        var errors = result.Errors.ToList();
                        return Json(new { response = errors });
                    }
                }
            }


            return Json("");
        }
        [HttpPost]
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Login");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallback()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                string error = "Error loading external login information";
                return RedirectToAction("Registration", "Home", error);
            }
            else
            {
                var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, true, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Profile", "Profile");
                }
                else
                {
                    var userName = info.Principal.FindFirstValue(ClaimTypes.Name);
                    var username = userName.Replace(" ", "_");
                    var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                    var firstname = info.Principal.FindFirstValue(ClaimTypes.GivenName);
                    var lastname = info.Principal.FindFirstValue(ClaimTypes.Surname);

                    if (email != null)
                    {
                        return View("ExternalRegister", new ExternalRegisterViewModel
                        {
                            Email = email,
                            Username = username,
                            Firstname = firstname,
                            Lastname = lastname
                        });
                    }
                    return RedirectToAction("Registration", "Home");
                }
            }

        }



        [HttpPost]
        public async Task<IActionResult> ExternalRegister(ExternalRegisterViewModel vm)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                string error = "Error loading external login information";
                return RedirectToAction("Registration", "Home", error);
            }

            var user = await _userManager.FindByEmailAsync(vm.Email);

            if (user == null)
            {
                user = new AppUser
                {
                    UserName = vm.Username,
                    Email = vm.Email,
                    EmailConfirmed = true

                };
                var userInfo = new UserInfo
                {
                    UserId = user.Id,
                    FirstName = vm.Firstname,
                    LastName = vm.Lastname,
                    Gender = vm.Gender,
                    DateOfBirth = vm.DateOfBirth,
                    Country = vm.Country,
                    CreationTime = DateTime.Now,
                    AccountStatus = AccountStatusEnum.Active
                };
                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    _regRepository.UserAdditionalInfo.Add(userInfo);
                    var signInResult = await _userManager.AddLoginAsync(user, info);

                    if (signInResult.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, true);
                        return RedirectToAction("Profile", "Profile");
                    }
                }
                else
                {
                    vm.Errors = new List<string>();
                    foreach(var error in result.Errors)
                    {
                        vm.Errors.Add(error.Description);
                    }
                    return View(vm);
                }
            }
            else
            {
                string emailError = $"Email is already used! You aren't able to sign up with {info.LoginProvider}!";
                TempData["Error"] = emailError;
                return RedirectToAction("Registration", "Home", TempData["Error"]);
            }
            return View(vm);
        }


    }

}
