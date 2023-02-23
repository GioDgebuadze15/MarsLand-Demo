using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebSite.AppServices.LogIn
{
    public interface ILogIn
    {
        Task<string> LogIn(string UsernameOrEmail,string logPassword);

        bool IsValidEmail(string UsernameOrEmail);

        string GetLogInError(SignInResult result);
        string GetUserEmail(string username);

        Task<IdentityResult> ResetPassword(string email, string newPassword);
    }
}
