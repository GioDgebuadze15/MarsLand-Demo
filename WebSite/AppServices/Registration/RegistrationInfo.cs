using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebSite.AppServices.MailVerification;
using WebSite.Cores;
using WebSite.EntityFramework.DbContext;
using WebSite.Enums;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.AppServices.Registration
{
    public class RegistrationInfo: IRegistrationInfo
    {
        private readonly AppDbContext _regRepository;
        private readonly UserManager<AppUser> _userManager;

        public RegistrationInfo(AppDbContext regRepository, UserManager<AppUser> userManager)
        {
            _regRepository = regRepository;
            _userManager = userManager;

        }
        public async Task<IdentityResult> CreateAppUser(RegistrationViewModel registrationViewModel)
        {
            var user = new AppUser
            {
                Email = registrationViewModel.Email,
                UserName = registrationViewModel.Username,
                PhoneNumber = registrationViewModel.PhoneNumber,
                
            };

            var result = await _userManager.CreateAsync(user, registrationViewModel.RegPassword);

            if (result.Succeeded)
            {
                
                await AddUserInfo(user, registrationViewModel);
                

            }
            return result;
        }
        public async Task AddUserInfo(AppUser identityUser, RegistrationViewModel registrationViewModel)
        {
                var user = new UserInfo
                {
                UserId= identityUser.Id,
                FirstName = registrationViewModel.FirstName,
                LastName = registrationViewModel.LastName,
                DateOfBirth = registrationViewModel.DateOfBirth,
                Gender = registrationViewModel.Gender,
                Country = registrationViewModel.Country,
                IpAddress = GetLocalIPAddress(),
                CreationTime = DateTime.Now,
                AccountStatus = AccountStatusEnum.Active
                };

             _regRepository.UserAdditionalInfo.Add(user);
             await _regRepository.SaveChangesAsync();
        }
        

        public List<string> GetErrors(IdentityResult result)
        {
            List<string> errors = new List<string>();
            foreach (var item in result.Errors)
            {
                errors.Add(item.Description);
            }
            return errors;
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        
    }
}
