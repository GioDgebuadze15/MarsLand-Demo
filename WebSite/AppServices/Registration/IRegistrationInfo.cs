using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebSite.Cores;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.AppServices.Registration
{
    public interface IRegistrationInfo
    {
        Task<IdentityResult> CreateAppUser(RegistrationViewModel registrationViewModel);
        Task AddUserInfo(AppUser identityUser, RegistrationViewModel registrationViewModel);
        List<string> GetErrors(IdentityResult result);

    }
}
