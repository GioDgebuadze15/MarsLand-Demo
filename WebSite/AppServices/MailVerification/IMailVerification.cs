using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebSite.Models;

namespace WebSite.AppServices.MailVerification
{
    public interface IMailVerification
    {
        MailVerificationModel GenerateEmailConfirmationCode(string email);
        bool SendMail(string email, int code);
        bool CompareCodes(MailVerificationModel mailVerificationModel);
        Task<string> CheckVerificationPurpose(MailVerificationModel mailVerificationModel);
        Task VerifyEmail(AppUser user);
    }
}
