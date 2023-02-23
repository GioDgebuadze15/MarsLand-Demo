using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebSite.AppServices.MailVerification;
using WebSite.Models;

namespace WebSite.AppServices.LogIn
{
    public class Login : ILogIn
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMailVerification _iMailVerification;

        public Login(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IMailVerification iMailVerification)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _iMailVerification = iMailVerification;
        }
        public async Task<string> LogIn(string UsernameOrEmail, string logPassword)
        {
            if (IsValidEmail(UsernameOrEmail))
            {
                var findUser = await _userManager.FindByEmailAsync(UsernameOrEmail);
                var Username = findUser.UserName;
                var result = await _signInManager.PasswordSignInAsync(Username, logPassword, true, false);

                if (!(result.Succeeded))
                {
                    string error = GetLogInError(result);

                    return error;
                }
                return "Successful";
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(UsernameOrEmail, logPassword, true, false);

                if (!(result.Succeeded))
                {
                    string error = GetLogInError(result);

                    return error;
                }
                return "Successful";
            }
        }

        public bool IsValidEmail(string UsernameOrEmail)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(UsernameOrEmail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetLogInError(SignInResult result)
        {
            string error;

            if (result.IsNotAllowed)
            {
                error = "ConfirmEmail";
            }
            else if (result.RequiresTwoFactor)
            {
                error = "Two factor verification is needed!";
            }
            else if (result.IsLockedOut)
            {
                error = "Your account is locked out";
            }
            else
            {
                error = "Username or Password is incorrect!";
            }
            return error;
        }

        public string GetUserEmail(string username)
        {
            var user = _userManager.FindByNameAsync(username).Result;
            if (user != null)
            {
                return user.Email;
            }
            else
            {
                return "";
            }
        }

        public async Task<IdentityResult> ResetPassword(string email, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(user, newPassword, true, false);

            }
            return result;


        }
    }
}
